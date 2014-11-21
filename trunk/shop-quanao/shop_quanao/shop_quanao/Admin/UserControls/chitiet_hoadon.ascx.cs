using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class chitiet_hoadon : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Redirect("~/Admin/hoadons.aspx");
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
                Entities.hoadon vhoadon = new Entities.hoadon();
                string errMsg = string.Empty;
                vhoadon = vcontroller.getby_hoadon(Request.QueryString["ID"], ref errMsg);
                txttenkhachhang.Text = vhoadon.Tenkhachhang;
                txtdiachi.Text = vhoadon.Diachi;
                txtsdt.Text = vhoadon.Sodienthoai;
                txtemail.Text = vhoadon.Email;
                txtngaydat.Text = vhoadon.Ngaydat.ToString("MM-dd-yyyy");
                txtngaygiao.Text = vhoadon.Ngaygiao.ToString("MM-dd-yyyy");

            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/hoadons.aspx");
        }
    }
}