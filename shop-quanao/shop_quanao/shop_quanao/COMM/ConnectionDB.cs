using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace shop_quanao.COMM
{
    public class ConnectionDB
    {
        public static SqlConnection cnn;
        public ConnectionDB()
        {
            //CHINH LAI DUONG DAN PHU HOP VOI CAU HINH SQLSERVER CUA BAN 
            string strcnn = ConfigurationManager.ConnectionStrings["shop_quanao"].ConnectionString;
            cnn = new SqlConnection(strcnn);
        }
        public static void Open()
        {
            cnn.Open();
        }
        public static void Close()
        {
            cnn.Close();
        }
    }
}