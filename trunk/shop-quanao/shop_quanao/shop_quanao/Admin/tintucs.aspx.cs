using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class tintucs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {
                uctintuc_add.Visible = false;
                uctintuc_list.Visible = true;
                uctintuc_update.Visible = false;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {
                    case "add":
                        uctintuc_add.Visible = true;
                        uctintuc_list.Visible = false;
                        uctintuc_update.Visible = false;
                        break;

                    case "update":
                        uctintuc_add.Visible = false;
                        uctintuc_list.Visible = false;
                        uctintuc_update.Visible = true;
                        break;

                    default:
                        uctintuc_add.Visible = false;
                        uctintuc_list.Visible = true;
                        uctintuc_update.Visible = false;

                        break;
                }
            }
        }
    }
}