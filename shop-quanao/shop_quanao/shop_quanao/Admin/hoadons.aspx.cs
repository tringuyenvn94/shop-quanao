using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class hoadons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {

                ucchitiet_hoadon.Visible = false;
                uchoadon_list.Visible = true;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {

                    case "view":
                        ucchitiet_hoadon.Visible = true;
                        uchoadon_list.Visible = false;
                        break;
                    default:
                        ucchitiet_hoadon.Visible = false;
                        uchoadon_list.Visible = true;

                        break;
                }
            }
        }
    }
}