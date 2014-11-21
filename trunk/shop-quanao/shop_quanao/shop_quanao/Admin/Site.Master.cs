using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null) { Response.Redirect("~/Admin/Login.aspx"); }
            lblFullname.Text = Convert.ToString(Session["FullName"]);
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}