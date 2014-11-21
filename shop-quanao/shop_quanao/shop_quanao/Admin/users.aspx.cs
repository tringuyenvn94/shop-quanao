using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {
                ucuser_add.Visible = false;
                ucuser_list.Visible = true;
                ucuser_update.Visible = false;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {
                    case "add":
                        ucuser_add.Visible = true;
                        ucuser_list.Visible = false;
                        ucuser_update.Visible = false;
                        break;

                    case "update":
                        ucuser_add.Visible = false;
                        ucuser_list.Visible = false;
                        ucuser_update.Visible = true;
                        break;

                    default:
                        ucuser_add.Visible = false;
                        ucuser_list.Visible = true;
                        ucuser_update.Visible = false;

                        break;
                }
            }
        }
    }
}