using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class ucbaocao_hoadon : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Redirect("~/Admin/baocaos.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack &&
           Visible)
            {
                FillData();
            }
        }
        private void FillData()
        {
            try
            {
                Admins vcontroller = new Admins();
                Entities.SanPham vsanpham = new Entities.SanPham();
                string errMsg = string.Empty;
                vsanpham = vcontroller.getby_sanpham(Request.QueryString["ID"], ref errMsg);
                lblsanpham.Text = vsanpham.TenSP;

            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/baocaos.aspx");
        }
    }
}