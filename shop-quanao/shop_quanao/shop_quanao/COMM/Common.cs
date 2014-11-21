using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace shop_quanao.COMM
{
    public static class Common
    {
        #region "Convert data ,check type data"
       
        /// <summary>
        /// Dung de insert kieu du lieu datetime vao CSDL 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static string ConvertDateToUSFormat(DateTime dt)
        {
            return dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString();

        }
        
        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static string ConvertDateToStandard(Nullable<DateTime> dt)
        {
            string temp = null;
            if ((dt.HasValue == false))
            {
                return "";
            }
            else
            {
                temp = StandalizeString(dt.Value.Day.ToString(), 2) + "/" + StandalizeString(dt.Value.Month.ToString(), 2) + "/" + StandalizeString(dt.Value.Year.ToString(), 4);
            }

            return temp;
        }
       
        /// <summary>
        /// Convert strign to integer
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static int ConvertStringToInt(string strValue)
        {

            try
            {
                return Convert.ToInt32(strValue);

            }
            catch (Exception ex)
            {
                return 0;

            }

        }
        
        /// <summary>
        /// COnvert string to DOuble
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static double ConvertStringToDouble(string strValue)
        {

            try
            {
                return Convert.ToDouble(strValue);

            }
            catch (Exception ex)
            {
                return 0;

            }

        }
        
        /// <summary>
        /// Convert strign to integer
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool isInt(string strValue)
        {

            try
            {
                int i = 0;
                i = Convert.ToInt32(strValue);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        /// <summary>
        /// Return true if input is Double
        /// else return false
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool isDouble(string strValue)
        {

            try
            {
                double i = 0;
                i = Convert.ToDouble(strValue);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        /// <summary>
        /// Check date is of data type datatime or not
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool isDateTime(string strValue)
        {

            try
            {
                string strValue_tem = strValue.Trim();
                if (strValue_tem.Length == 0)
                {
                    return true;

                }
                // dem so /
                int index = 0;
                int count = 0;
                for (index = 0; index <= strValue_tem.Length - 1; index++)
                {
                    if (strValue_tem.Substring(index, 1) == "/")
                    {
                        count = count + 1;
                    }

                }

                if (count != 2)
                {
                    return false;
                }
                //---------- kiem tra ngay / thang / nam
                string[] arrNgay = strValue_tem.Split(new Char[] { '/' });
                if (arrNgay[0].Length <= 1)
                {
                    arrNgay[0] = "0" + arrNgay[0];
                }
                if (arrNgay[1].Length <= 1)
                {
                    arrNgay[1] = "0" + arrNgay[1];
                }

                strValue_tem = arrNgay[0] + "/" + arrNgay[1] + "/" + arrNgay[2];


                if (strValue_tem.Length != 10)
                {
                    return false;
                }
                string ngay = strValue_tem.Substring(0, 2);
                string thang = strValue_tem.Substring(3, 2);
                string nam = strValue_tem.Substring(6, 4);
                DateTime i = new DateTime(Convert.ToInt32(nam), Convert.ToInt32(thang), Convert.ToInt32(ngay));

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Convert 1 chuoi ra integer hoac null
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static Nullable<int> ConvertStr2IntNull(string strValue)
        {


            try
            {
                return Convert.ToInt32(strValue);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Check date is of data type datatime or not
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks> 
       
        public static Nullable<DateTime> ConvertString2Date(string strValue)
        {

            try
            {
                // Dim dateTemp As DateTime
                string sDate = null;
                string sMonth = null;
                string sYear = null;
                int iDate = 0;
                int iMonth = 0;
                int iYear = 0;
                sDate = strValue.Substring(0, 2);
                sMonth = strValue.Substring(3, 2);
                sYear = strValue.Substring(6, 4);
                if ((string.IsNullOrEmpty(sDate)) | (string.IsNullOrEmpty(sMonth)) | (string.IsNullOrEmpty(sYear)))
                {
                    return null;
                }
                // get iDate 
                iDate = Convert.ToInt32(sDate);
                // get iMonth
                iMonth = Convert.ToInt32(sMonth);

                // get iYear
                iYear = Convert.ToInt32(sYear);
                // dateTemp = Convert.ToDateTime(strValue)
                DateTime dateTemp = new DateTime(iYear, iMonth, iDate);
                return dateTemp;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// COnvert chuoi khogn day du vi du 3/4/2010 sang kieu Date
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static Nullable<DateTime> ConvertString_notFull_2NullableDate(string strValue)
        {


            try
            {
                //---------------------
                string strValue_tem = strValue;

                //---------- kiem tra ngay / thang / nam
                string[] arrNgay = strValue_tem.Split(new Char[] { '/' });
                if (arrNgay[0].Length <= 1)
                {
                    arrNgay[0] = "0" + arrNgay[0];
                }
                if (arrNgay[1].Length <= 1)
                {
                    arrNgay[1] = "0" + arrNgay[1];
                }

                strValue_tem = arrNgay[0] + "/" + arrNgay[1] + "/" + arrNgay[2];


                //-----------------------------------
                // Dim dateTemp As DateTime
                string sDate = null;
                string sMonth = null;
                string sYear = null;
                int iDate = 0;
                int iMonth = 0;
                int iYear = 0;
                sDate = strValue_tem.Substring(0, 2);
                sMonth = strValue_tem.Substring(3, 2);
                sYear = strValue_tem.Substring(6, 4);
                if ((string.IsNullOrEmpty(sDate)) | (string.IsNullOrEmpty(sMonth)) | (string.IsNullOrEmpty(sYear)))
                {
                    return null;
                }
                // get iDate 
                iDate = Convert.ToInt32(sDate);
                // get iMonth
                iMonth = Convert.ToInt32(sMonth);

                // get iYear
                iYear = Convert.ToInt32(sYear);
                // dateTemp = Convert.ToDateTime(strValue)
                DateTime dateTemp = new DateTime(iYear, iMonth, iDate);
                return dateTemp;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        
        /// <summary>
        /// check is numeric 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static bool IsNumeric(string input)
        {
            decimal output = 0;
            return decimal.TryParse(input, out output);
        }

        /// <summary>
        /// Check date is of data type datatime or not
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks> 
        
        public static Nullable<DateTime> ConvertString2DateNullable(string strValue)
        {

            try
            {
                if (strValue == string.Empty)
                {
                    return null;
                }
                else
                {
                    return ConvertString2Date(strValue);

                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Convert integer to sttring with space sparate thousand 
        /// input e.g : 23190
        /// output : "23 190"
        /// </summary>
        /// <param name="value_int"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static string ConvertInt2StringWithCharSeparate(Nullable<int> value_int)
        {
            try
            {
                if (value_int.HasValue == false)
                {
                    return string.Empty;
                }

                string strValue_tem = value_int.Value.ToString();

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

        public static string ConvertInt2StringWithCharSeparate(Nullable<int> value_int, string charSeparate)
        {


            try
            {
                if (value_int.HasValue == false)
                {
                    return string.Empty;
                }

                string strValue_tem = value_int.Value.ToString();

                int index = 0;
                string strResult = string.Empty;
                for (index = strValue_tem.Length - 1; index >= 0; index += -1)
                {
                    int index_new = strValue_tem.Length - 1 - index;
                    if (Math.IEEERemainder(index_new, 3) == 0 & index_new > 0)
                    {
                        strResult = strValue_tem.Substring(index, 1) + charSeparate + strResult;
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

        /// <summary>
        /// Chuyen 1 so decimal thanh 1 so co dinh dang
        /// Vi du : 1234.400 thanh 1,234.4
        /// </summary>
        /// <param name="value_dec"></param>
        /// <param name="charSeparate"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static string ConvertDecimal2StringWithCharSeparate(Nullable<decimal> value_dec, string charSeparate)
        {


            try
            {
                if (value_dec.HasValue == false)
                {
                    return string.Empty;
                }

                double Tem_Double = double.Parse(value_dec.Value.ToString());
                int Tem_Int;
                double Tem_Dec = 0;
                string strResult = null;

                Tem_Int = (int)Math.Truncate(Tem_Double);
                Tem_Dec = Tem_Double - Convert.ToDouble(Tem_Int);
                if (Tem_Dec == 0)
                {
                    strResult = Common.ConvertInt2StringWithCharSeparate(Tem_Int, charSeparate);

                }
                else
                {
                    string strDec = Tem_Double.ToString().Replace(Tem_Int.ToString() + ".", "");

                    strResult = Common.ConvertInt2StringWithCharSeparate(Tem_Int, charSeparate) + "." + strDec;


                }


                return strResult;


            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        
        /// <summary>
        /// Create by : Nguyen QUyet Dinh
        /// Check date is of data type datatime or not
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static Nullable<DateTime> ConvertObj2Date(object obj)
        {

            try
            {
                DateTime dateTemp = default(DateTime);
                dateTemp = Convert.ToDateTime(obj.ToString());
                return dateTemp;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string ConvertData2String(DateTime dtime)
        {


            try
            {
                return StandalizeString(dtime.Day.ToString(), 2) + "/" + StandalizeString(dtime.Month.ToString(), 2) + "/" + StandalizeString(dtime.Year.ToString(), 4);


            }
            catch (Exception ex)
            {
                return "00/00/0000";

            }

        }

        /// <summary>
        /// Convert date to string format yyyy_dd_dd
        /// </summary>
        /// <param name="dtime"></param>
        /// <returns></returns>
        
        public static string ConvertDate2String_yyyy_mm_dd(DateTime dtime)
        {


            try
            {


                return StandalizeString(dtime.Year.ToString(), 4) + '_' + StandalizeString(dtime.Month.ToString(), 2) + '_' + StandalizeString(dtime.Day.ToString(), 2);

            }
            catch (Exception ex)
            {
                return "00/00/0000";

            }

        }

        public static string ConvertDate2String_yyyy_mm_dd_HH_MMi_SS(DateTime dtime)
        {


            try
            {
                return StandalizeString(dtime.Year.ToString(), 4) + '_' + StandalizeString(dtime.Month.ToString(), 2) + '_' + StandalizeString(dtime.Day.ToString(), 2)
                    + '_' + StandalizeString(dtime.Hour.ToString(), 2) + '_' + StandalizeString(dtime.Minute.ToString(), 2) + '_' + StandalizeString(dtime.Second.ToString(), 2);

            }
            catch (Exception ex)
            {
                return "00/00/0000";

            }

        }

        /// <summary>
        /// Convet object to Integer
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static int ConvertObj2Int(object obj)
        {


            try
            {
                return Convert.ToInt32(obj.ToString());


            }
            catch (Exception ex)
            {
                return 0;

            }

        }
        
        /// <summary>
        /// Convet object to Decimal
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static decimal ConvertObj2Decimal(object obj)
        {


            try
            {
                return decimal.Parse(obj.ToString());


            }
            catch (Exception ex)
            {
                return 0;

            }

        }

        public static Nullable<decimal> ConvertObj2Nullable_Decimal(object obj)
        {


            try
            {
                return decimal.Parse(obj.ToString());


            }
            catch (Exception ex)
            {
                return null;

            }

        }
       
        /// <summary>
        /// Convet object to Integer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static Nullable<int> ConvertObj2IntNullable(object obj)
        {


            try
            {
                return Convert.ToInt32(obj.ToString());


            }
            catch (Exception ex)
            {
                return null;

            }

        }

        /// <summary>
        /// Convert obj to nullable of boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static Nullable<bool> ConvertObj2BoolNullable(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj.ToString());
            }
            catch (Exception ex)
            {
                return null;

            }

        }
       
        /// <summary>
        /// Convet object to Integer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static bool ConvertObj2Boolean(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj.ToString());

            }
            catch (Exception ex)
            {
                return false;
            }

        }
       
        public static decimal ConvertString2Decaimal(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
       
        public static string ConvertDate2String(DateTime dtime)
        {
            try
            {
                return StandalizeString(dtime.Day.ToString(), 2) + "/" + StandalizeString(dtime.Month.ToString(), 2) + "/" + StandalizeString(dtime.Year.ToString(), 4);
            }
            catch (Exception ex)
            {
                return "";

            }

        }
       
        /// <summary>
        /// Out put format : mm/dd/yyyy
        /// </summary>
        /// <param name="dtime"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static string ConvertDate2StringUS(DateTime dtime)
        {
            try
            {
                return StandalizeString(dtime.Month.ToString(), 2) + "/" + StandalizeString(dtime.Day.ToString(), 2) + "/" + StandalizeString(dtime.Year.ToString(), 4);
            }
            catch (Exception ex)
            {
                return "";

            }

        }

        public static string ConvertObj2String(object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public static string StandalizeString(string strInput, int len)
        {
            try
            {
                int count = 0;
                string result = "";
                for (count = 1; count <= len; count += 1)
                {
                    if ((count <= strInput.Length))
                    {
                        result = result + strInput.Substring(count - 1, 1);
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                return strInput;

            }

        }

        /// <summary>
        /// Input : datatable Eg Cell(0,0)="3" ;Cell(1,0)="5"
        /// Ouput : string "3;5;"
        /// </summary>
        /// <param name="dtable"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static string ConvertDatatable2String(DataTable dtable)
        {
            try
            {
                string Str = string.Empty;
                int count = 0;

                for (count = 0; count <= dtable.Rows.Count - 1; count += 1)
                {
                    Str = Str + dtable.Rows[count][0].ToString() + ";";
                }
                return Str;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        #endregion

        #region "lam viec voi error"
       
        /// <summary>
        /// Show error onlabel
        /// 
        /// </summary>
        /// <param name="lbl">Control with error to show </param>
        /// <param name="strError"> string error message to show </param>
        /// <returns></returns>
        /// <remarks></remarks>

        public static void SetError(ref Label lbl, string strError)
        {
            try
            {
                lbl.Visible = true;
                lbl.ForeColor = System.Drawing.Color.Red;
                lbl.Text = strError;
            }
            catch (Exception ex)
            {
            }

        }
      
        /// <summary>
        /// Check xem  text box co duoc nhap du lieu khong va show message
        /// return true neu khong co error xay ra
        /// else return false
        /// </summary>
        /// <param name="txtBox"></param>        
        /// <param name="lbl"></param>
        /// <param name="strError"></param>
        /// <remarks></remarks>
        
        public static bool CheckTextBoxHasDataAndSetError(TextBox txtBox, ref Label lbl, string strError)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBox.Text.Trim()))
                {
                    Common.SetError(ref lbl, strError);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Check xem text box co du lieu vuot qua do dai cho phep hay khong
        /// return true neu ko co loi xay ra
        /// else return false
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="maxLen"></param>
        /// <param name="lbl"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static bool CheckLenTextBoxAndSetError(TextBox txtBox, int maxLen, ref Label lbl, string strError)
        {
            try
            {
                if (txtBox.Text.Length > maxLen)
                {
                    Common.SetError(ref lbl, strError);
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
     
        /// <summary>
        /// Xoa error 
        /// Show error onlabel
        /// </summary>
        /// <param name="lbl"></param>
        /// <remarks></remarks>
        /// 
        
        public static void ClearError(ref Label lbl)
        {
            try
            {
                lbl.Visible = false;
                lbl.ForeColor = System.Drawing.Color.Black;
                lbl.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// Hien thi ket qua successfull 
        /// Show error onlabel
        ///       

        public static void ShowSussecc(ref Label lbl, string strMsg)
        {
            try
            {
                lbl.Visible = true;
                lbl.ForeColor = System.Drawing.Color.Blue;
                lbl.Text = strMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        /// <remarks></remarks>

        public static void ShowMsg(ref Label lbl, string strMsg_err, string strMsgOK)
        {
            try
            {
                if (strMsg_err != string.Empty)
                {
                    Common.SetError(ref lbl, "Error : " + strMsg_err);
                }
                else
                {
                    Common.ShowSussecc(ref lbl, strMsgOK);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ShowErrorMsg_by_web_form(string eMsg)
        {
            try
            {
                System.IO.TextWriter textWriter = null;
                HttpResponse instance = new HttpResponse(textWriter);
                string url = null;
                instance.Redirect("../ErrorMsg.aspx?ErrorMsg=" + eMsg);

            }
            catch (Exception ex)
            {
                throw ex;
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

        #endregion

        #region "mot so ham lam viec voi user control"
        
        /// <summary>
        /// For: fill data to dropdown list
        /// exampale:
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// call example : FillDataToDropdownList( drpDM_BoPhan, "tblDM_BoPhan","ID_BoPhan","Ten_BoPhan",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool FillDataToDropdownList(ref DropDownList drp, string table_nameInput, string data_field, string display_field, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput;

                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        /// <summary>
        /// For: fill data to dropdown list
        /// exampale :
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// call example : FillDataToDropdownList( drpDM_BoPhan, "tblDM_BoPhan","ID_BoPhan","Ten_BoPhan",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static bool FillDataToDropdownList(ref DropDownList drp, string table_nameInput, string data_field, string display_field, string @where, string order, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;

                if (@where.Trim() == string.Empty & order.Trim() == string.Empty)
                {
                    sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput;
                }
                else if (@where.Trim() != string.Empty & order.Trim() == string.Empty)
                {
                    sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + @where;
                }
                else if (@where.Trim() == string.Empty & order.Trim() != string.Empty)
                {
                    sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " ORDER BY " + order;

                }
                else if (@where.Trim() != string.Empty & order.Trim() != string.Empty)
                {
                    sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + @where + " ORDER BY " + order;
                }


                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
                return false;

            }

        }

        /// <summary>
        /// For: fill data to dropdown list
        /// exampale :
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// call example : FillDataToDropdownList( drpDM_BoPhan, "tblDM_BoPhan","ID_BoPhan","Ten_BoPhan",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static bool FillDataToDropdownList_StringDataField(ref DropDownList drp, string table_nameInput, string data_field, string display_field, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT '' as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput;

                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        /// <summary>
        /// For: fill data to dropdown list
        /// exampale :
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// call example : FillDataToDropdownList( drpDM_BoPhan, "tblDM_BoPhan","ID_BoPhan","Ten_BoPhan",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool FillDataToDropdownList_StringDataField_where(ref DropDownList drp, string table_nameInput, string data_field, string display_field, string whre, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT '' as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + whre;

                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        /// <summary>
        /// For: fill data to dropdown list
        /// exampale :
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// filter : la dieu kien loc data
        /// call example : FillDataToDropdownList( drpDuAN, "tblDuAn","Nam =2008","ID_DuAn","Ten_DuAn",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool FillDataToDropdownList(ref DropDownList drp, string table_nameInput, string filter, string data_field, string display_field, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT -1 as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + filter;

                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
       
        /// <summary>
        /// Fill data to dropdown list without empty item
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="filter"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static bool FillDataToDropdownList_WithoutEmptyItem(ref DropDownList drp, string table_nameInput, string filter, string orderBy, string data_field, string display_field, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                if (filter.Trim() == string.Empty)
                {
                    if (orderBy.Trim() == string.Empty)
                    {
                        sqlStr = "SELECT " + data_field + "," + display_field + " FROM " + table_nameInput;
                    }
                    else
                    {
                        sqlStr = "SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + "  ORDER BY " + orderBy;
                    }
                }
                else
                {
                    if (orderBy.Trim() == string.Empty)
                    {
                        sqlStr = "SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + filter;
                    }
                    else
                    {
                        sqlStr = "SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + filter + "  ORDER BY " + orderBy;
                    }

                }


                drp.DataSource = SQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        #endregion

        #region "Mot so ham so sanh"
        
        /// <summary>
        /// For : compare date 
        /// return 1 : if date1 > date 2
        ///; return 0 : date1 =date 2
        ///; return -1 : date1 be hon date2
        /// return 2 : if date1 or date2 is empty
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        public static int CompareDate(string date1, string date2)
        {

            try
            {
                if (date1.Trim() == string.Empty | date2.Trim() == string.Empty)
                {
                    return 4;
                }
                System.DateTime? dt1 = ConvertString2Date(date1);
                System.DateTime? dt2 = ConvertString2Date(date2);
                if (dt1 > dt2)
                {
                    return 1;

                }
                else
                {
                    if (dt1 == dt2)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;

                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
                throw ex;
            }

        }
        
        /// <summary>
        /// So sanh ngay thang
        ///  return 1 : if date1 > date 2
        ///  return 0 : date1 =date 2
        /// return -1 : date1 be hon date2
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static int CompareDate(System.DateTime date1, System.DateTime date2)
        {


            try
            {

                if (date1 > date2)
                {
                    return 1;

                }
                else
                {
                    if (date1 == date2)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;

                    }

                }

            }
            catch (Exception ex)
            {
                return 1;
                throw ex;
            }

        }

        #endregion

        #region "Mot so ham phu tro"

        /// <summary>
        ///  Get ngay hien tai tren server
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static DateTime GetCurrentDate_FromServer()
        {
            string strSQL = null;
            string errMsg = null;
            strSQL = "select datepart( dd,getdate()) as crrDay , datepart( mm,getdate()) as crrMonth,datepart( yyyy,getdate()) as crrYear";
            int crrDay = 0;
            int crrMonth = 0;
            int crrYear = 0;
            DataTable dtDate = SQLExecute.LoadDataFromDB(strSQL, "temTB", ref errMsg);
            crrDay = Common.ConvertObj2Int(dtDate.Rows[0]["crrDay"].ToString());

            crrMonth = Common.ConvertObj2Int(dtDate.Rows[0]["crrMonth"].ToString());
            crrYear = Common.ConvertObj2Int(dtDate.Rows[0]["crrYear"].ToString());

            DateTime crrDate = new DateTime(crrYear, crrMonth, crrDay);
            return crrDate;
        }

        /// <summary>
        /// Return current time in SQL server
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static DateTime GetCurrentDateTime_FromServer()
        {
            string strSQL = null;
            string errMsg = null;
            strSQL = "select datepart( dd,getdate()) as crrDay , datepart( mm,getdate()) as crrMonth,datepart( yyyy,getdate()) as crrYear  , datepart( hh ,getdate()) as crrHour , datepart( mi ,getdate()) as crrMinute , datepart( ss ,getdate()) as crrSecond  ";
            int crrDay = 0;
            int crrMonth = 0;
            int crrYear = 0;
            int crrHour = 0;
            int crrMinute = 0;
            int crrSecond = 0;

            DataTable dtDate = SQLExecute.LoadDataFromDB(strSQL, "temTB", ref errMsg);
            crrDay = Common.ConvertObj2Int(dtDate.Rows[0]["crrDay"].ToString());

            crrMonth = Common.ConvertObj2Int(dtDate.Rows[0]["crrMonth"].ToString());
            crrYear = Common.ConvertObj2Int(dtDate.Rows[0]["crrYear"].ToString());
            // hour , minite, second

            crrHour = Common.ConvertObj2Int(dtDate.Rows[0]["crrHour"].ToString());

            crrMinute = Common.ConvertObj2Int(dtDate.Rows[0]["crrMinute"].ToString());
            crrSecond = Common.ConvertObj2Int(dtDate.Rows[0]["crrSecond"].ToString());


            DateTime crrDate = new DateTime(crrYear, crrMonth, crrDay, crrHour, crrMinute, crrSecond);
            return crrDate;


        }

        public static DateTime GetCurrentTime_FromServer()
        {
            string strSQL = null;
            string errMsg = null;
            strSQL = "select datepart( dd,getdate()) as crrDay , datepart( mm,getdate()) as crrMonth,datepart( yyyy,getdate()) as crrYear  , datepart( hh ,getdate()) as crrHour , datepart( mi ,getdate()) as crrMinute , datepart( ss ,getdate()) as crrSecond  ";

            int crrHour = 0;
            int crrMinute = 0;
            int crrSecond = 0;

            DataTable dtDate = SQLExecute.LoadDataFromDB(strSQL, "temTB", ref errMsg);

            // hour , minite, second

            crrHour = Common.ConvertObj2Int(dtDate.Rows[0]["crrHour"].ToString());

            crrMinute = Common.ConvertObj2Int(dtDate.Rows[0]["crrMinute"].ToString());
            crrSecond = Common.ConvertObj2Int(dtDate.Rows[0]["crrSecond"].ToString());


            DateTime crrDate = new DateTime(crrHour, crrMinute, crrSecond);
            return crrDate;


        }

        /// <summary>
        /// So sanh so ngay lech nhau giua date1 va date2
        /// ket qua > 0 thi date 2 sau date 1
        /// ket qua be hon 0 thi date1 truoc date2
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        
        public static int NumberDayDiff(DateTime date1, DateTime date2)
        {

            int numDayDiff = DateTime.Compare(date1, date2);

            return numDayDiff;



        }

        /// <summary>
        /// return ID max for insert
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNameID"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        /// <remarks></remarks>
       
        public static int GetID_MaxForInsert(string tableName, string colNameID, string strWhere)
        {

            string errMsg = string.Empty;
            DataTable dtID_max = null;
            if (strWhere.Trim() == string.Empty)
            {
                dtID_max = SQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName, "temTB", ref errMsg);

            }
            else
            {
                dtID_max = SQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName + " where " + strWhere, "temTB", ref errMsg);

            }

            if (Convert.IsDBNull(dtID_max.Rows[0][0]))
            {
                return 1;

            }
            else
            {
                return Convert.ToInt32(dtID_max.Rows[0][0]) + 1;

            }
        }

        /// <summary>
        /// remove 1 column in table
        /// </summary>
        /// <param name="tblInput"></param>
        /// <param name="colName"></param>
        /// <remarks></remarks>
        public static DataTable RemoveColumnInTable(ref DataTable tblInput, string colName)
        {

            int index = 0;

            for (index = 0; index <= tblInput.Columns.Count - 1; index++)
            {
                if (tblInput.Columns[index].ColumnName == colName)
                {
                    tblInput.Columns.Remove(colName);
                    return tblInput;
                }
            }

            return tblInput;

        }


        /// <summary>
        /// thay the tat ca 1 doan trong van ban = 1 doan moi
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="strOld"></param>
        /// <param name="strNew"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ReplaceAllStringByNewString(string strInput, string strOld, string strNew)
        {

            string str_tem = strInput;
            while (str_tem.Contains(strOld))
            {
                str_tem = str_tem.Replace(strOld, strNew);
            }

            return str_tem;
        }
        #endregion

        #region "mot so ham phu tro"

        /// <summary>
        ///  thay the tat ca chuoi chua str_replace bang str_replace_by As String)
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="str_replace"></param>
        /// <param name="str_replace_by"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ReplaceAll_ForString(string strInput, string str_replace, string str_replace_by)
        {
            string strInput_tem = strInput;
            while (strInput_tem.Contains(str_replace))
            {
                strInput_tem = strInput_tem.Replace(str_replace, str_replace_by);

            }
            return strInput_tem;

        }

        /// <summary>
        /// get thoi tian luc hien tai tren may local : yyyy:mm:dd hh:pp:ss
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetCurrentTimeFromServer()
        {

            string str_date = StandalizeString(DateTime.Now.Year.ToString(), 4) + ":" + StandalizeString(DateTime.Now.Month.ToString(), 2) + ":" + StandalizeString(DateTime.Now.Day.ToString(), 2);
            string str_time = StandalizeString(DateTime.Now.Hour.ToString(), 2) + ":" + StandalizeString(DateTime.Now.Minute.ToString(), 2) + ":" + StandalizeString(DateTime.Now.Second.ToString(), 2);

            return str_date + " " + str_time;
        }

        #endregion

        #region " lam viec voi column kieu image trong SQL server"
        /// <summary>
        /// Save list of byte to a table is SQL into column with image datatype 
        /// </summary>
        /// <param name="data"> data to save</param>
        /// <param name="isInsertNew"> =true : save new data; =false : append data</param>
        /// <param name="sTableStore">Table de save</param>
        /// <param name="sColumnStore">Colum de save</param>
        /// <param name="sWhereGetRow"> Dieu kien de cho ra row</param>
        /// <param name="errMsg"></param>
        /// <remarks></remarks>

        public static void Save_BytesArrayToTable_SQLServer(byte[] data, bool isInsertNew_dataBytes, string sTableStore, string sColumnStore, string sWhereGetRow, ref string errMsg)
        {

            try
            {
                string strSQL_WithParameters = null;
                if (isInsertNew_dataBytes)
                {
                    if (sWhereGetRow.Trim() != string.Empty)
                    {
                        strSQL_WithParameters = "update " + sTableStore + " set  " + sColumnStore + " = @" + sColumnStore + " where " + sWhereGetRow;

                    }
                    else
                    {
                        strSQL_WithParameters = "update " + sTableStore + " set " + sColumnStore + " = @" + sColumnStore;

                    }

                }

                System.Data.SqlClient.SqlParameter[] prms = new SqlParameter[2];
                prms[0] = new System.Data.SqlClient.SqlParameter("@" + sColumnStore, System.Data.SqlDbType.Image);
                prms[0].Value = data;

                SQLExecute.Excute_SQL_String_withParameters(strSQL_WithParameters, ref prms, 1, ref errMsg);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw ex;
            }
            finally
            {

            }
        }

        #endregion

        #region "Ham ma hoa, giai ma"

        public static string Encode(string sInput)
        {
            return sInput;
        }



        public static string Decode(string sInput)
        {
            return sInput;
        }

        /// <summary>
        /// return true neu chuoi chi gom cac ky tu a ..z va cac chu so 0 .. 9
        /// else return false
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool StringContainA_Zora_zor0_9(string strIn)
        {
            bool functionReturnValue = false;
            functionReturnValue = true;
            int i = 0;
            int j = 0;
            bool absent = false;
            for (i = 1; i <= strIn.Length; i++)
            {
                absent = false;
                for (j = 1; j <= 26; j++)
                {
                    if (strIn.Substring(i, 1) == Convert.ToChar(64 + j).ToString())
                    {
                        absent = true;
                    }
                    if (strIn.Substring(i, 1) == Convert.ToChar((int)('a') + j - 1).ToString())
                    {
                        absent = true;
                    }
                }
                for (j = 0; j <= 9; j++)
                {
                    if (strIn.Substring(i, 1) == Convert.ToChar((int)('0') + j).ToString())
                    {
                        absent = true;
                    }
                }
                if (absent == false)
                {
                    functionReturnValue = false;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return functionReturnValue;

        }


        /// <summary>
        /// Xoa file voi duogn dan file full
        /// </summary>
        /// <param name="strFileName"></param>
        /// <remarks></remarks>

        public static void DeleteFile(string strFileName)
        {
            try
            {

                if (strFileName.Trim().Length > 0)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(strFileName);

                    //if file exists, delete it
                    if ((fi.Exists))
                    {
                        fi.Delete();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// return true : neu da ton tai file do trogn thu muc
        /// else return false
        /// </summary>
        /// <param name="strFileFullName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool CheckFileExist(string strFileFullName)
        {

            try
            {

                if (strFileFullName.Trim().Length > 0)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(strFileFullName);

                    //if file exists, delete it
                    if ((fi.Exists))
                    {

                        return true;
                    }

                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        #endregion



    }
}