using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class Sizes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {
                ucSize_add.Visible = false;
                ucSize_list.Visible = true;
                ucSize_update.Visible = false;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {
                    case "add":
                        ucSize_add.Visible = true;
                        ucSize_list.Visible = false;
                        ucSize_update.Visible = false;
                        break;

                    case "update":
                        ucSize_add.Visible = false;
                        ucSize_list.Visible = false;
                        ucSize_update.Visible = true;
                        break;

                    default:
                        ucSize_add.Visible = false;
                        ucSize_list.Visible = true;
                        ucSize_update.Visible = false;

                        break;
                }
            }
        }
    }
}