using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.UserControls
{
    public partial class dangky : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndangky_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txttenkhachhang.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtmatkhau.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txttenkhachhang.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtsdt.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtdiachi.Text))
            {
                return;
            }
            try
            {
                Admins vcontroller = new Admins();
                Entities.KhachHang vusers = new Entities.KhachHang();
                string errMsg = string.Empty;
                vusers.Tendangnhap = txttenkhachhang.Text;
                vusers.Matkhau = txtmatkhau.Text;
                vusers.Email = txtemail.Text;
                vusers.Hoten = txttenkhachhang.Text;
                vusers.Sodienthoai = txtsdt.Text;
                vusers.Diachi = txtdiachi.Text;
                vusers.Laadmin = false;
                vusers.Trangthai = true;
                vusers.Gioitinh = Convert.ToInt32(ddlgioitinh.SelectedValue);
                int result = vcontroller.save_khachhang(vusers, ref errMsg);
                if (result > 0)
                {
                    Response.Redirect("~/dangnhap.aspx");
                }
                else
                {
                    if (result == -1) { throw new Exception("Sai tên tài khoản hoặc mật khẩu!"); }
                    else { throw new Exception("Hệ thống gặp sự cố trong quá trình xác thực tài khoản!"); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hệ thống gặp sự cố trong quá trình xác thực tài khoản!");
            }
        }
    }
}