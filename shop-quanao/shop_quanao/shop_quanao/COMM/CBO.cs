using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace shop_quanao.COMM
{
    public class CBO
    {
        public static bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double testDouble;
            if (double.TryParse(expression.ToString(), out testDouble))
                return true;

            //VB's 'IsNumeric' returns true for any boolean value:
            bool testBool;
            if (bool.TryParse(expression.ToString(), out testBool))
                return true;

            return false;
        }
        public static ArrayList GetPropertyInfo(Type objType)
        {

            // Use the cache because the reflection used later is expensive
            ArrayList objProperties = null;
            //= CType(DataCache.GetCache(objType.FullName), ArrayList)

            if (objProperties == null)
            {
                objProperties = new ArrayList();
                PropertyInfo objProperty = null;
                foreach (PropertyInfo objProperty_loopVariable in objType.GetProperties())
                {
                    objProperty = objProperty_loopVariable;
                    objProperties.Add(objProperty);
                }
                //DataCache.SetCache(objType.FullName, objProperties)
            }

            return objProperties;

        }

        private static int[] GetOrdinals(ArrayList objProperties, IDataReader dr)
        {

            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty = 0;

            if ((dr != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        arrOrdinals[intProperty] = dr.GetOrdinal(((PropertyInfo)objProperties[intProperty]).Name);
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return arrOrdinals;

        }

        private static object CreateObject(Type objType, IDataReader dr, ArrayList objProperties, int[] arrOrdinals)
        {

            PropertyInfo objPropertyInfo = null;
            object objValue = null;
            Type objPropertyType = null;
            int intProperty = 0;

            object objObject = Activator.CreateInstance(objType);

            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                            }
                            catch
                            {
                                // business object info class member data type does not match datareader member data type
                                try
                                {
                                    objPropertyType = objPropertyInfo.PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (objPropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        // check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        if (IsNumeric(dr.GetValue(arrOrdinals[intProperty])))
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals[intProperty]))), null);
                                        }
                                        else
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals[intProperty])), null);
                                        }
                                    }
                                    else if (objPropertyType.FullName.Equals("System.Guid"))
                                    {
                                        // guid is not a datatype common across all databases ( ie. Oracle )
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(new Guid(dr.GetValue(arrOrdinals[intProperty]).ToString()), objPropertyType), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                    }
                                }
                                catch
                                {
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                }
                            }
                        }
                    }
                    else
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return objObject;

        }

        public static object FillObject(IDataReader dr, Type objType)
        {

            return FillObject(dr, objType, true);

        }

        public static object FillObject(IDataReader dr, Type objType, bool ManageDataReader)
        {

            object objFillObject = null;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            bool Continue = false;
            if (ManageDataReader)
            {
                Continue = false;
                // read datareader
                if (dr.Read())
                {
                    Continue = true;
                }
            }
            else
            {
                Continue = true;
            }

            if (Continue)
            {
                // create custom business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }

            if (ManageDataReader)
            {
                // close datareader
                if ((dr != null))
                {
                    dr.Close();
                }
            }

            return objFillObject;

        }

        public static ArrayList FillCollection(IDataReader dr, Type objType)
        {

            ArrayList objFillCollection = new ArrayList();
            object objFillObject = null;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objFillCollection;

        }

        public static IList FillCollection(IDataReader dr, Type objType, ref IList objToFill)
        {

            object objFillObject = null;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objToFill.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objToFill;

        }

        public static object InitializeObject(object objObject, Type objType)
        {

            PropertyInfo objPropertyInfo = null;
            object objValue = null;
            int intProperty = 0;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // initialize properties
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    objPropertyInfo.SetValue(objObject, objValue, null);
                }
            }

            return objObject;

        }

        public static XmlDocument Serialize(object objObject)
        {

            XmlSerializer objXmlSerializer = new XmlSerializer(objObject.GetType());

            StringBuilder objStringBuilder = new StringBuilder();

            TextWriter objTextWriter = new StringWriter(objStringBuilder);

            objXmlSerializer.Serialize(objTextWriter, objObject);

            StringReader objStringReader = new StringReader(objTextWriter.ToString());

            DataSet objDataSet = new DataSet();

            objDataSet.ReadXml(objStringReader);

            XmlDocument xmlSerializedObject = new XmlDocument();

            xmlSerializedObject.LoadXml(objDataSet.GetXml());

            return xmlSerializedObject;

        }

        //Public Shared Function CloneObject(ByVal ObjectToClone As Object) As Object    'Implements System.ICloneable.Clone
        //    'Try
        //    '    Dim newObject As Object = DotNetNuke.Framework.Reflection.CreateObject(ObjectToClone.GetType().AssemblyQualifiedName, ObjectToClone.GetType().AssemblyQualifiedName)

        //    '    Dim props As ArrayList = GetPropertyInfo(newObject.GetType())

        //    '    Dim i As Integer = 0

        //    '    For i = 0 To GetPropertyInfo(ObjectToClone.GetType()).Count - 1
        //    '        Dim p As PropertyInfo = CType(GetPropertyInfo(ObjectToClone.GetType())(i), PropertyInfo)

        //    '        Dim ICloneType As Type = p.PropertyType.GetInterface("ICloneable", True)
        //    '        If CType(props(i), PropertyInfo).CanWrite Then
        //    '            If Not (ICloneType Is Nothing) Then
        //    '                Dim IClone As ICloneable = CType(p.GetValue(ObjectToClone, Nothing), ICloneable)
        //    '                CType(props(i), PropertyInfo).SetValue(newObject, IClone.Clone(), Nothing)
        //    '            Else
        //    '                CType(props(i), PropertyInfo).SetValue(newObject, p.GetValue(ObjectToClone, Nothing), Nothing)
        //    '            End If

        //    '            Dim IEnumerableType As Type = p.PropertyType.GetInterface("IEnumerable", True)
        //    '            If Not (IEnumerableType Is Nothing) Then
        //    '                Dim IEnum As IEnumerable = CType(p.GetValue(ObjectToClone, Nothing), IEnumerable)

        //    '                Dim IListType As Type = CType(props(i), PropertyInfo).PropertyType.GetInterface("IList", True)
        //    '                Dim IDicType As Type = CType(props(i), PropertyInfo).PropertyType.GetInterface("IDictionary", True)

        //    '                Dim j As Integer = 0
        //    '                If Not (IListType Is Nothing) Then
        //    '                    Dim list As IList = CType(CType(props(i), PropertyInfo).GetValue(newObject, Nothing), IList)

        //    '                    Dim obj As Object
        //    '                    For Each obj In IEnum
        //    '                        ICloneType = obj.GetType().GetInterface("ICloneable", True)

        //    '                        If Not (ICloneType Is Nothing) Then
        //    '                            Dim tmpClone As ICloneable = CType(obj, ICloneable)
        //    '                            list(j) = tmpClone.Clone()
        //    '                        End If

        //    '                        j += 1
        //    '                    Next obj
        //    '                Else
        //    '                    If Not (IDicType Is Nothing) Then
        //    '                        Dim dic As IDictionary = CType(CType(props(i), PropertyInfo).GetValue(newObject, Nothing), IDictionary)
        //    '                        j = 0

        //    '                        Dim de As DictionaryEntry
        //    '                        For Each de In IEnum

        //    '                            ICloneType = de.Value.GetType().GetInterface("ICloneable", True)

        //    '                            If Not (ICloneType Is Nothing) Then
        //    '                                Dim tmpClone As ICloneable = CType(de.Value, ICloneable)
        //    '                                dic(de.Key) = tmpClone.Clone()
        //    '                            End If
        //    '                            j += 1
        //    '                        Next de
        //    '                    End If
        //    '                End If
        //    '            End If
        //    '        End If
        //    '    Next
        //    '    Return newObject
        //    'Catch exc As Exception
        //    '    LogException(exc)
        //    '    Return Nothing
        //    'End Try
        //End Function


        /// <summary>
        /// Sonpt
        /// <returns></returns>
        /// <remarks></remarks>

        #region "Generic Methods"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of CreateObject creates an object of a specified type from the 
        /// provided DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The DataReader</param>
        /// <returns>The custom business object</returns>
        /// <remarks></remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static T CreateObject<T>(IDataReader dr)
        {

            PropertyInfo objPropertyInfo = null;
            object objValue = null;
            Type objPropertyType = null;
            int intProperty = 0;

            T objObject = Activator.CreateInstance<T>();

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objObject.GetType());

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                            }
                            catch
                            {
                                // business object info class member data type does not match datareader member data type
                                try
                                {
                                    objPropertyType = objPropertyInfo.PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (objPropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        // check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        if (IsNumeric(dr.GetValue(arrOrdinals[intProperty])))
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals[intProperty]))), null);
                                        }
                                        else
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals[intProperty])), null);
                                        }
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                    }
                                }
                                catch
                                {
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                }
                            }
                        }
                    }
                    else
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return objObject;

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillCollection fills a List custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <returns>A List of custom business objects</returns>
        /// <remarks></remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static List<T> FillCollection<T>(IDataReader dr)
        {

            List<T> objFillCollection = new List<T>();
            T objFillObject = default(T);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject<T>(dr);
                // add to collection
                objFillCollection.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objFillCollection;

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillCollection fills a provided IList with custom business 
        /// objects of a specified type from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <param name="objToFill">The IList to fill</param>
        /// <returns>An IList of custom business objects</returns>
        /// <remarks></remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static IList<T> FillCollection<T>(IDataReader dr, ref IList<T> objToFill)
        {

            T objFillObject = default(T);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject<T>(dr);
                // add to collection
                objToFill.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objToFill;

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillObject fills a custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <returns>The object</returns>
        /// <remarks>This overloads sets the ManageDataReader parameter to true and calls 
        /// the other overload</remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static T FillObject<T>(IDataReader dr)
        {

            return FillObject<T>(dr, true);

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillObject fills a custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <param name="ManageDataReader">A boolean that determines whether the DatReader
        /// is managed</param>
        /// <returns>The object</returns>
        /// <remarks>This overloads allows the caller to determine whether the ManageDataReader 
        /// parameter is set</remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static T FillObject<T>(IDataReader dr, bool ManageDataReader)
        {

            T objFillObject = default(T);

            bool Continue = false;
            if (ManageDataReader)
            {
                Continue = false;
                // read datareader
                if (dr.Read())
                {
                    Continue = true;
                }
            }
            else
            {
                Continue = true;
            }

            if (Continue)
            {
                // create custom business object
                objFillObject = CreateObject<T>(dr);
            }
            else
            {

            }

            if (ManageDataReader)
            {
                // close datareader
                if ((dr != null))
                {
                    dr.Close();
                }
            }

            return objFillObject;

        }



        #endregion



    }
    public static class publicfunction
    {
        public static string ConvertInt2StringWithCharSeparate(int value_Dec)
        {
            try
            {
                string strValue_tem = value_Dec.ToString();

                int index = 0;
                string strResult = string.Empty;

                for (index = strValue_tem.Length - 1; index >= 0; index += -1)
                {
                    int index_new = strValue_tem.Length - 1 - index;
                    if (Math.IEEERemainder(index_new, 3) == 0 & index_new > 0)
                    {
                        strResult = strValue_tem.Substring(index, 1) + "," + strResult;
                    }
                    else
                    {
                        strResult = strValue_tem.Substring(index, 1) + strResult;
                    }
                }

                return strResult;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}