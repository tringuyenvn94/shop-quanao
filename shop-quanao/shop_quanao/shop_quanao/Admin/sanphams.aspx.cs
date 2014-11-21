using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class sanphams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {
                ucsanpham_add.Visible = false;
                ucsanpham_list.Visible = true;
                ucsanpham_update.Visible = false;
                ucsanpham_update_sl.Visible = false;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {
                    case "add":
                        ucsanpham_add.Visible = true;
                        ucsanpham_list.Visible = false;
                        ucsanpham_update.Visible = false;
                        ucsanpham_update_sl.Visible = false;
                        break;

                    case "update":
                        ucsanpham_add.Visible = false;
                        ucsanpham_list.Visible = false;
                        ucsanpham_update.Visible = true;
                        ucsanpham_update_sl.Visible = false;
                        break;

                    case "update_sl":
                        ucsanpham_add.Visible = false;
                        ucsanpham_list.Visible = false;
                        ucsanpham_update.Visible = false;
                        ucsanpham_update_sl.Visible = true;
                        break;
                    default:
                        ucsanpham_add.Visible = false;
                        ucsanpham_list.Visible = true;
                        ucsanpham_update.Visible = false;
                        ucsanpham_update_sl.Visible = false;

                        break;
                }
            }
        }
    }
}