using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class user_add : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Visible)
            {
                ucNotificationDialog.Hide();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txttendangnhap.Text))
            {
                NotificationMessage("tên đăng nhập không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txtmatkhau.Text))
            {
                NotificationMessage("mật khẩu không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txthoten.Text))
            {
                NotificationMessage("họ tên không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                NotificationMessage("email không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txtsdt.Text))
            {
                NotificationMessage("số điện thoại không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txtdiachi.Text))
            {
                NotificationMessage("địa chỉ không được để trống", 0);
                return;
            }
            try
            {
                Admins vcontroller = new Admins();
                Entities.KhachHang vusers = new Entities.KhachHang();
                string errMsg = string.Empty;
                vusers.Tendangnhap = txttendangnhap.Text;
                vusers.Matkhau = txtmatkhau.Text;
                vusers.Email = txtemail.Text;
                vusers.Hoten = txthoten.Text;
                vusers.Sodienthoai = txtsdt.Text;
                vusers.Diachi = txtdiachi.Text;
                vusers.Laadmin = true;
                vusers.Trangthai = true;
                vusers.Gioitinh = Convert.ToInt32(ddlgioitinh.SelectedValue);
                int result = vcontroller.save_khachhang(vusers, ref errMsg);
                if (result > 0)
                {
                    ucNotificationDialog.MessageContent = "Thêm mới user thành công!";
                    ucNotificationDialog.MessageType = 1;
                    ucNotificationDialog.RedirectUrl = "~/Admin/users.aspx";
                    ucNotificationDialog.Show();
                }
                else
                {
                    NotificationMessage("Vui lòng kiểm tra lại.", 0);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                NotificationMessage("Hệ thống gặp sự cố trong quá trình thêm user mới!", 0);
            }
        }

        private void NotificationMessage(string _MessageContent, int _MessageType)
        {
            ucNotificationDialog.MessageContent = _MessageContent;
            ucNotificationDialog.MessageType = _MessageType;
            ucNotificationDialog.Show();
            return;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/users.aspx");
        }

    }
}