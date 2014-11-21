using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class user_update : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        { }
        bool valtrangthai = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Redirect("~/Admin/users.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack &&
           Visible)
            {
                ucNotificationDialog.Visible = false;
                ucConfirmDialog.Hide();
                FillData();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txttendangnhap.Text))
            {
                NotificationMessage("tên đăng nhập không được để trống", 0);
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

            ucConfirmDialog.MessageContent = "Bạn có chắc chắn muốn cập nhật User này không?";
            ucConfirmDialog.Show();
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

        protected void ucConfirmDialog_Yes(object sender)
        {
            ucConfirmDialog.Hide();

            try
            {

                Admins vcontroller = new Admins();
                Entities.KhachHang vusers = new Entities.KhachHang();
                string errMsg = string.Empty;
                vusers.MaKH = Convert.ToInt32(Request.QueryString["ID"]);
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
                    ucNotificationDialog.MessageContent = "cập nhập user thành công!";
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
                ucNotificationDialog.MessageContent = "Hệ thống gặp sự cố trong quá trình cập nhật !";
                ucNotificationDialog.MessageType = 0;
                ucNotificationDialog.Show();
            }
        }

        protected void ucConfirmDialog_No(object sender)
        {
            ucConfirmDialog.Hide();
            Response.Redirect("~/Admin/users.aspx");
        }

        private void FillData()
        {
            try
            {
                Admins vcontroller = new Admins();
                Entities.KhachHang vusers = new Entities.KhachHang();
                string errMsg = string.Empty;
                vusers = vcontroller.getby_tk_khachhang_ID(Request.QueryString["ID"], ref errMsg);
                txttendangnhap.Text = vusers.Tendangnhap;
                txttendangnhap.Enabled = false;
                txtmatkhau.Text = vusers.Matkhau;
                txtemail.Text = vusers.Email;
                ddlgioitinh.SelectedIndex = vusers.Gioitinh;
                txthoten.Text = vusers.Hoten;
                txtsdt.Text = vusers.Sodienthoai;
                txtdiachi.Text = vusers.Diachi;
                valtrangthai = vusers.Trangthai;
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.ucConfirmDialog.Yes += new YesEventHandler(ucConfirmDialog_Yes);
            this.ucConfirmDialog.No += new NoEventHandler(ucConfirmDialog_No);
            this.Init += new EventHandler(this.Page_Init);
        }
    }
}