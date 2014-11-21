using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace shop_quanao.COMM
{
    public class SQLExecute
    {
        private static SqlConnection oConn = new System.Data.SqlClient.SqlConnection();

        // Dung ham sau de tao connection toi CSDL
        // Return true : Có nghĩa đã thực hiện thành công truy vấn
        // Return false : Có nghĩa không thực hiên thành công

        public static bool TaoConnectByDB_onwner(ref SqlConnection oConn)
        {
            string gConnStr = null;
            string ExMsg = null;
            ExMsg = string.Empty;
            gConnStr = ConfigurationManager.ConnectionStrings["shop_quanao"].ConnectionString; ;

            if ((oConn.State == ConnectionState.Open))
            {
                return true;
            }
            try
            {
                oConn.ConnectionString = gConnStr;

                oConn.Open();
                ExMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                //ExMsg = ex.Message
                ExMsg = "Error : Can not connect to database !";
                return false;
            }
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["shop_quanao"].ToString();
        }

        public static bool TaoConnection()
        {
            string gConnStr = null;
            string ExMsg = null;
            ExMsg = string.Empty;
            gConnStr = ConfigurationManager.ConnectionStrings["shop_quanao"].ToString();
            if ((oConn.State == ConnectionState.Open))
            {
                return true;
            }
            try
            {
                oConn.ConnectionString = gConnStr;

                oConn.Open();
                ExMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                //ExMsg = ex.Message
                ExMsg = "Error : Can not connect to database !";
                return false;
            }
        }

        // DUng ham sau de thuc hien 1 cau truy van tra lai 1 datatable


        // DUng ham sau de thuc hien 1 cau truy van hoac thuc hien 1 store procedure de tra lai 1 datatable

        public static DataTable LoadDataFromDB2(string LoadSql, string TableName, ref string ExMsg)
        {


            //Dim Conn As New SqlClient.SqlConnection

            SqlCommand cmd = null;

            SqlDataAdapter dadp = null;

            DataSet ds = null;


            try
            {
                ExMsg = string.Empty;
                if ((TaoConnection() == false))
                {
                    ExMsg = " Error : Can not connect to database !";
                    return null;
                }

                cmd = new System.Data.SqlClient.SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = LoadSql;



                dadp = new SqlDataAdapter(cmd);

                ds = new DataSet();

                dadp.Fill(ds, TableName);

                return ds.Tables[TableName];


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return null;


            }
            finally
            {
                //cmd.Dispose()
                //Conn.Dispose()
                //If Not (dadp Is Nothing) Then dadp.Dispose()

                //If Not (ds Is Nothing) Then ds.Dispose()

                cmd = null;

                dadp = null;

                ds = null;
                // Conn = Nothing

            }

        }

        // DUng ham sau de thuc hien 1 cau truy van hoac thuc hien 1 store procedure de tra lai 1 datatable
        public static DataTable LoadDataFromDB(string LoadSql, string TableName, ref string ExMsg, CommandType cmdType = CommandType.Text, System.Data.SqlClient.SqlParameter[] Prms = null, int PrmCount = 0)
        {


            //Dim Conn As New SqlClient.SqlConnection

            SqlCommand cmd = null;

            SqlDataAdapter dadp = null;

            DataSet ds = null;


            try
            {
                ExMsg = string.Empty;
                if ((TaoConnection() == false))
                {
                    ExMsg = " Error : Can not connect to database !";
                    return null;
                }

                cmd = new SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = cmdType;

                cmd.CommandText = LoadSql;


                if ((Prms != null))
                {

                    for (int i = 0; i <= PrmCount - 1; i++)
                    {
                        cmd.Parameters.Add(Prms[i]);

                    }

                }

                dadp = new SqlDataAdapter(cmd);

                ds = new DataSet();

                dadp.Fill(ds, TableName);


                for (int i = PrmCount - 1; i >= 0; i += -1)
                {
                    cmd.Parameters.RemoveAt(i);

                }

                return ds.Tables[TableName];


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return null;


            }
            finally
            {
                //cmd.Dispose();
                //Conn.Dispose();
                //If Not (dadp Is Nothing) Then dadp.Dispose()

                //If Not (ds Is Nothing) Then ds.Dispose()

                cmd = null;

                dadp = null;

                ds = null;
                // Conn = Nothing

            }

        }

        public static DataTable LoadDataFromDBPage(string SpName, ref SqlParameter[] Prms, int PrmCount, ref string ExMsg, ref int rowcount)
        {

            SqlCommand cmd = null;
            SqlDataAdapter dadp = null;

            DataSet ds = null;
            //  Dim Conn As New SqlClient.SqlConnection
            int i = 0;

            try
            {
                if ((TaoConnection() == false))
                {
                    ExMsg = "Error : Can not connect to database !";
                    return null;

                }

                cmd = new System.Data.SqlClient.SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = SpName;

                for (i = 0; i <= PrmCount - 1; i++)
                {
                    //  cmd.Parameters.Add(Prms(i))
                    if (((Prms[i].Value == null) || (object.ReferenceEquals(Prms[i].Value.GetType(), typeof(System.DBNull)))))
                    {
                        SqlParameter temPara = new SqlParameter();
                        temPara.ParameterName = Prms[i].ParameterName;
                        temPara.Value = DBNull.Value;
                        temPara.Size = Prms[i].Size;
                        temPara.Direction = Prms[i].Direction;
                        cmd.Parameters.Add(temPara);

                    }
                    else
                    {
                        cmd.Parameters.Add(Prms[i]);
                    }
                }

                dadp = new SqlDataAdapter(cmd);

                ds = new DataSet();

                dadp.Fill(ds, "tmpData");

                rowcount = Convert.ToInt32(cmd.Parameters["@outrowcount"].Value.ToString());
                for (i = PrmCount - 1; i >= 0; i += -1)
                {
                    cmd.Parameters.RemoveAt(i);

                }

                return ds.Tables["tmpData"];


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return null;


            }
            finally
            {
                cmd = null;
                dadp = null;
                ds = null;


            }

        }

        public static int ExcuteSPOutput(string SpName, ref SqlParameter[] Prms, int PrmCount, ref string ExMsg, string outreturn)
        {

            SqlCommand cmd = null;

            //  Dim Conn As New SqlClient.SqlConnection
            int i = 0;
            int result = 0;

            try
            {
                if ((TaoConnection() == false))
                {
                    ExMsg = "Error : Can not connect to database !";
                    return -1;

                }

                cmd = new SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = SpName;

                for (i = 0; i <= PrmCount - 1; i++)
                {
                    //  cmd.Parameters.Add(Prms(i))
                    if (((Prms[i].Value == null) || (object.ReferenceEquals(Prms[i].Value.GetType(), typeof(System.DBNull)))))
                    {
                        SqlParameter temPara = new SqlParameter();
                        temPara.ParameterName = Prms[i].ParameterName;
                        temPara.Value = DBNull.Value;
                        temPara.Size = Prms[i].Size;
                        temPara.Direction = Prms[i].Direction;
                        cmd.Parameters.Add(temPara);

                    }
                    else
                    {
                        cmd.Parameters.Add(Prms[i]);
                    }
                }

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters[outreturn].Value.ToString());
                for (i = PrmCount - 1; i >= 0; i += -1)
                {
                    cmd.Parameters.RemoveAt(i);

                }

                return result;


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return -1;


            }
            finally
            {
                cmd = null;
                // Conn = Nothing

            }

        }

        // Dung ham sau de thuc hien 1 store procedure voi tham so 
        public static bool ExcuteSP(string SpName, ref SqlParameter[] Prms, int PrmCount, ref string ExMsg)
        {

            SqlCommand cmd = null;

            //  Dim Conn As New SqlClient.SqlConnection
            int i = 0;


            try
            {
                if ((TaoConnection() == false))
                {
                    ExMsg = "Error : Can not connect to database !";
                    return false;

                }

                cmd = new SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = SpName;

                for (i = 0; i <= PrmCount - 1; i++)
                {
                    //  cmd.Parameters.Add(Prms(i))
                    if (((Prms[i].Value == null) || (object.ReferenceEquals(Prms[i].Value.GetType(), typeof(System.DBNull)))))
                    {
                        SqlParameter temPara = new SqlParameter();
                        temPara.ParameterName = Prms[i].ParameterName;
                        temPara.Value = DBNull.Value;
                        temPara.Direction = Prms[i].Direction;
                        cmd.Parameters.Add(temPara);

                    }
                    else
                    {
                        cmd.Parameters.Add(Prms[i]);
                    }
                }

                cmd.ExecuteNonQuery();


                for (i = PrmCount - 1; i >= 0; i += -1)
                {
                    cmd.Parameters.RemoveAt(i);

                }

                return true;


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return false;


            }
            finally
            {
                cmd = null;
                // Conn = Nothing

            }

        }

         //  Dung ham sau de thuc hien 1 sql String voi tham so
        public static bool Excute_SQL_String_withParameters(string strSQL_withPara, ref SqlParameter[] Prms, int PrmCount, ref string ExMsg)
        {

            SqlCommand cmd = null;

            //  Dim Conn As New SqlClient.SqlConnection
            int i = 0;


            try
            {
                if ((TaoConnection() == false))
                {
                    ExMsg = "Error : Can not connect to database !";
                    return false;

                }

                cmd = new SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = strSQL_withPara;

                for (i = 0; i <= PrmCount - 1; i++)
                {
                    //  cmd.Parameters.Add(Prms(i))
                    if (((Prms[i].Value == null) || (object.ReferenceEquals(Prms[i].Value.GetType(), typeof(System.DBNull)))))
                    {
                        SqlParameter temPara = new SqlParameter();
                        temPara.ParameterName = Prms[i].ParameterName;
                        temPara.Value = DBNull.Value;
                        cmd.Parameters.Add(temPara);

                    }
                    else
                    {
                        cmd.Parameters.Add(Prms[i]);
                    }
                }

                cmd.ExecuteNonQuery();


                for (i = PrmCount - 1; i >= 0; i += -1)
                {
                    cmd.Parameters.RemoveAt(i);

                }

                return true;


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return false;


            }
            finally
            {
                cmd = null;


            }

        }

        // Dung ham sau de thuc hien 1 store procedure khong co tham so 
        // Return true : Có nghĩa đã thực hiện thành công truy vấn
        // Return false : Có nghĩa không thực hiên thành công
        
        public static bool ExcuteSP_NoParam(string SpName, ref string ExMsg)
        {

            SqlCommand cmd = null;
            // Dim Conn As New SqlClient.SqlConnection
            int i = 0;

            try
            {
                if ((TaoConnection() == false))
                {
                    ExMsg = "Error : Can not connect to database !";
                    return false;
                }

                cmd = new SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = SpName;

                cmd.ExecuteNonQuery();


                return true;


            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;

                return false;


            }
            finally
            {
                //  cmd.Dispose()

                cmd = null;
                // Conn = Nothing

            }

        }

        // Dung ham sau de thuc hien cau lenh SQL khogn tra lai datatable
        // Return true : Có nghĩa đã thực hiện thành công truy vấn
        // Return false : Có nghĩa không thực hiên thành công
        
        public static bool ExcuteSQL(string Sql, ref string ExMsg)
        {
            bool functionReturnValue = false;

            SqlCommand cmd = null;
            //   Dim Conn As New SqlClient.SqlConnection

            int i = 0;


            try
            {
                ExMsg = string.Empty;
                if ((TaoConnection() == false))
                {
                    ExMsg = " Error : Can not connect to database !";
                    return false;
                }

                cmd = new SqlCommand();
                cmd.Connection = oConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();

                return true;

                //Catch ex As System.Data.SqlClient.SqlException
                //    Throw ex
                //    'Return False
                //    ExcuteSQL = False
            }
            catch (Exception ex)
            {
                ExMsg = ex.Message;
                functionReturnValue = false;
                //Return False
                //Finally
                //    'cmd.Dispose()
                //    cmd = Nothing
                //    '  Conn = Nothing

            }
            return functionReturnValue;

        }

        /// <summary>
        ///  ' get data from table by where caluse....
        /// return : datatable type
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="arrColsName"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        ///
        
        public static DataTable GetDataFromTable(string tableName, Array arrColsName, string whereClause, string orderBy, ref string errMsg)
        {

            string strSQL = null;
            int arrSize;
            int index;
            string strCols = null;
            DataTable temp = null;
            arrSize = arrColsName.Length;

            // with where 
            if ((whereClause.Trim().Length > 0))
            {

                // with order
                if ((orderBy.Trim().Length > 0))
                {
                    if (arrSize == 1)
                    {
                        strSQL = " select " + arrColsName.GetValue(0).ToString() + "  from " + tableName + " where " + whereClause + " order by " + orderBy;
                    }
                    else
                    {
                        strCols = string.Empty;
                        for (index = 0; index <= arrSize - 2; index++)
                        {
                            //strCols = strCols + arrColsName(index).ToString() + ",";
                            strCols = strCols + arrColsName.GetValue(index).ToString() + ",";
                        }
                        //strCols = strCols + arrColsName(arrSize - 1).ToString();
                        strCols = strCols + arrColsName.GetValue(arrSize - 1).ToString();
                        strSQL = " select " + strCols + "  from " + tableName + " where " + whereClause + " order by " + orderBy;
                    }

                    // without  order
                }
                else
                {
                    if (arrSize == 1)
                    {
                        strSQL = " select " + arrColsName.GetValue(0).ToString() + "  from " + tableName + " where " + whereClause;
                    }
                    else
                    {
                        strCols = string.Empty;
                        for (index = 0; index <= arrSize - 2; index++)
                        {
                            strCols = strCols + arrColsName.GetValue(index).ToString() + ",";
                        }
                        strCols = strCols + arrColsName.GetValue(arrSize - 1).ToString();
                        strSQL = " select " + strCols + "  from " + tableName + " where " + whereClause;
                    }

                }
                // without where   
            }
            else
            {

                // with order by
                if ((orderBy.Trim().Length > 0))
                {
                    if (arrSize == 1)
                    {
                        strSQL = " select " + arrColsName.GetValue(0).ToString() + "  from " + tableName + " order by " + orderBy;
                    }
                    else
                    {
                        strCols = string.Empty;
                        for (index = 0; index <= arrSize - 2; index++)
                        {
                            strCols = strCols + arrColsName.GetValue(index).ToString() + ",";
                        }
                        strCols = strCols + arrColsName.GetValue(arrSize - 1).ToString();
                        strSQL = " select " + strCols + "  from " + tableName + " order by " + orderBy;
                    }

                    // without order by
                }
                else
                {
                    if (arrSize == 1)
                    {
                        strSQL = " select " + arrColsName.GetValue(0).ToString() + "  from " + tableName;
                    }
                    else
                    {
                        strCols = string.Empty;
                        for (index = 0; index <= arrSize - 2; index++)
                        {
                            strCols = strCols + arrColsName.GetValue(index).ToString() + ",";
                        }
                        strCols = strCols + arrColsName.GetValue(arrSize - 1).ToString();
                        strSQL = " select " + strCols + "  from " + tableName;
                    }


                }
            }
            //===============

            temp = SQLExecute.LoadDataFromDB(strSQL, tableName, ref errMsg);

            return temp;
        }
        
        /// <summary>
        /// Get value from table by where Clause
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="arrColsName"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        public static string GetValueFromTable(string tableName, string colName_ToGetValue, string whereClause, string orderBy, ref string errMsg)
        {

            string strSQL = null;
            Int32 arrSize = default(Int32);
            Int32 index = default(Int32);
            string strCols = null;
            DataTable temp = null;
            try
            {
                // with where 
                if ((whereClause.Trim().Length > 0))
                {

                    // with order
                    if ((orderBy.Trim().Length > 0))
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause + " order by " + orderBy;

                        // without  order
                    }
                    else
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause;

                    }
                    // without where   
                }
                else
                {

                    // with order by
                    if ((orderBy.Trim().Length > 0))
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " order by " + orderBy;

                        // without order by
                    }
                    else
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName;

                    }
                }
                //===============

                temp = SQLExecute.LoadDataFromDB(strSQL, tableName, ref errMsg);

                if ((temp.Rows.Count > 0))
                {
                    errMsg = "";
                    return temp.Rows[0][colName_ToGetValue].ToString();
                }
                else
                {
                    errMsg = "No data found";
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }




        }

        /// <summary>
        /// Get list of value from Table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName_ToGetValue"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static List<string> GetListOf_ValuesFromTable(string tableName, string colName_ToGetValue, string whereClause, string orderBy, ref string errMsg)
        {

            string strSQL = null;
            Int32 arrSize = default(Int32);
            Int32 index = default(Int32);
            string strCols = null;
            DataTable temp = null;
            try
            {
                // with where 
                if ((whereClause.Trim().Length > 0))
                {

                    // with order
                    if ((orderBy.Trim().Length > 0))
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause + " order by " + orderBy;

                        // without  order
                    }
                    else
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause;

                    }
                    // without where   
                }
                else
                {

                    // with order by
                    if ((orderBy.Trim().Length > 0))
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName + " order by " + orderBy;

                        // without order by
                    }
                    else
                    {

                        strSQL = " select " + colName_ToGetValue + "  from " + tableName;

                    }
                }
                //===============

                temp = SQLExecute.LoadDataFromDB(strSQL, tableName, ref errMsg);

                if ((temp.Rows.Count > 0))
                {
                    errMsg = "";

                    List<string> lstValue = new List<string>();
                    int i = 0;

                    for (i = 0; i <= temp.Rows.Count - 1; i++)
                    {
                        lstValue.Add(temp.Rows[i][colName_ToGetValue].ToString());
                    }
                    return lstValue;
                }
                else
                {
                    errMsg = "No data found";
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }




        }

        /// <summary>
        /// get gia tri trong column kieu du lieu image
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName_ToGetValue"></param>
        /// <param name="whereClause"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static byte[] GetBytesArrayFromTable(string tableName, string colName_ToGetValue, string whereClause, ref string errMsg)
        {

            string strSQL = null;
            Int32 arrSize = default(Int32);
            Int32 index = default(Int32);
            string strCols = null;
            DataTable temp = null;

            try
            {
                errMsg = string.Empty;
                // with where 
                if ((whereClause.Trim().Length > 0))
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause;

                    // without where   
                }
                else
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName;

                }

                System.Data.SqlClient.SqlCommand cmd = null;

                if ((TaoConnection() == false))
                {
                    errMsg = " Error : Can not connect to database !";
                    return null;
                }

                cmd = new System.Data.SqlClient.SqlCommand();

                cmd.Connection = oConn;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = strSQL;

                cmd.ExecuteNonQuery();

                return (byte[])cmd.ExecuteScalar();



            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }


        }
        
        /// <summary>
        /// return : true if exist data when execute sql string
        /// return false if not exist
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool CheckExistDataBySQL_clause(string strSQL)
        {

            try
            {
                string errMsg = string.Empty;
                DataTable dt = SQLExecute.LoadDataFromDB(strSQL, "tem", ref errMsg);

                if (dt.Rows.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        /// <summary>
        /// Dung de get 1 gia tri kieu datetime trong 1 bang 
        /// Chu y : Truong du lieu lay ra phai la kieu datetime
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName_ToGetValue"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static Nullable<DateTime> GetDateValueFromTable(string tableName, string colName_ToGetValue, string whereClause, string orderBy, ref string errMsg)
        {

            string strSQL = null;
            Int32 arrSize = default(Int32);
            Int32 index = default(Int32);
            string strCols = null;
            DataTable temp = null;

            // with where 
            if ((whereClause.Trim().Length > 0))
            {

                // with order
                if ((orderBy.Trim().Length > 0))
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause + " order by " + orderBy;

                    // without  order
                }
                else
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName + " where " + whereClause;

                }
                // without where   
            }
            else
            {

                // with order by
                if ((orderBy.Trim().Length > 0))
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName + " order by " + orderBy;

                    // without order by
                }
                else
                {

                    strSQL = " select " + colName_ToGetValue + "  from " + tableName;

                }
            }


            temp = SQLExecute.LoadDataFromDB(strSQL, tableName, ref errMsg);

            if ((temp.Rows.Count > 0))
            {
                errMsg = "";
                if (Convert.IsDBNull(temp.Rows[0][colName_ToGetValue]))
                {
                    return null;
                }
                else
                {
                    return DateTime.Parse(temp.Rows[0][colName_ToGetValue].ToString());
                }

            }
            else
            {
                errMsg = "No data found !";
            }

            return null;

        }

        /// <summary>
        /// return number row of table from selecting
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="whereClause"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static int GetNumberRowInTable(string tableName, string whereClause, ref string errMsg)
        {

            string strSQL = null;
            DataTable temp = null;

            // with where 
            if ((whereClause.Trim().Length > 0))
            {
                strSQL = " select count(*) AS numberRow  from " + tableName + " where " + whereClause;
                // without where   
            }
            else
            {
                strSQL = " select count(*) AS numberRow    from " + tableName;
            }
            //===============
            temp = SQLExecute.LoadDataFromDB(strSQL, tableName, ref errMsg);
            if ((string.IsNullOrEmpty(errMsg)))
            {
                return Convert.ToInt32(temp.Rows[0][0]);
            }
            else
            {
                return -1;
                // error
            }

            return -1;
            // error

        }
        
        /// <summary>
        /// Date : 24/02/2010
        /// tao Idatareeader cho cac class
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static IDataReader getIDataReader(string sqlstr, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                if ((TaoConnection() == false))
                {
                    errMsg = "Error : Can not connect to database !";
                    return null;
                }
                //re oConn
                SqlCommand cmd = new SqlCommand(sqlstr, oConn);
                IDataReader dr = (IDataReader)cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }

        }

    }
}