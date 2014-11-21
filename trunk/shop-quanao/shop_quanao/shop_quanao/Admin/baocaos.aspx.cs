using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin
{
    public partial class baocaos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]))
            {

                ucbaocao_hoadon.Visible = false;
                ucbaocao.Visible = true;
            }
            else
            {
                switch (Request.QueryString["module"].ToLower())
                {

                    case "view":
                        ucbaocao_hoadon.Visible = true;
                        ucbaocao.Visible = false;
                        break;
                    default:
                        ucbaocao_hoadon.Visible = false;
                        ucbaocao.Visible = true;

                        break;
                }
            }
        }
    }
}