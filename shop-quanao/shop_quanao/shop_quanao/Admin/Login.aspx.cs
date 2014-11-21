using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AlertNotification.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Admins vcontroller = new Admins();
                Entities.KhachHang vusers = new Entities.KhachHang();
                string errMsg = string.Empty;
                int result = vcontroller.Login_khachhang(true, txtUserName.Text, txtPassword.Text, ref errMsg);

                if (result > 0)
                {
                    vusers = vcontroller.getby_tk_khachhang(txtUserName.Text, ref errMsg);

                    if (vusers != null)
                    {
                        Session.Add("UserID", Convert.ToInt32(vusers.MaKH));
                        Session.Add("FullName", Convert.ToString(vusers.Hoten));
                        Response.Redirect("~/Admin/users.aspx");
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
                AlertNotification.Visible = true;
                lblAlert.Text = ex.Message;
            }
        }
    }
}