using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.UserControls
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                EndUser vcontroller_enduser = new EndUser();
                Admins vcontroller_admin = new Admins();
                Entities.KhachHang vkhachhang = new Entities.KhachHang();
                string errMsg = string.Empty;
                int result = vcontroller_admin.Login_khachhang(false, txtusername.Text, txtmakhau.Text, ref errMsg);

                if (result > 0)
                {
                    vkhachhang = vcontroller_admin.getby_tk_khachhang(txtusername.Text, ref errMsg);

                    if (vkhachhang != null)
                    {
                        Session.Add("KhachhangID", Convert.ToInt32(vkhachhang.MaKH));
                        Session.Add("FullName_KH", Convert.ToString(vkhachhang.Hoten));
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    if (result == -1) { throw new Exception("Sai tên tài khoản hoặc mật khẩu!"); }
                    else { throw new Exception("Hệ thống gặp sự cố trong quá trình xác thực tài khoản!"); }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}