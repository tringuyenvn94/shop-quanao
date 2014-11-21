using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class sanpham_update_sl : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        { }
        private string urlhinhanh = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Redirect("~/Admin/sanphams.aspx");
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
            ucConfirmDialog.MessageContent = "Bạn có chắc chắn muốn cập nhật sản phẩm này không?";
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
            Response.Redirect("~/Admin/sanphams.aspx");
        }

        protected void ucConfirmDialog_Yes(object sender)
        {
            ucConfirmDialog.Hide();

            try
            {
                Admins vcontroller = new Admins();
                string errMsg = string.Empty;
                string[] listid = Convert.ToString(Request.QueryString["ID"]).Split(new char[] { ',' });
                int masp = Convert.ToInt32(listid[0]);
                int masize = Convert.ToInt32(listid[1]);
                int result = vcontroller.update_soluong_sp(masp, masize, Convert.ToInt32(txtsoluong.Text), ref errMsg);
                if (result > 0)
                {
                    ucNotificationDialog.MessageContent = "cập nhập số lượng sản phẩm thành công!";
                    ucNotificationDialog.MessageType = 1;
                    ucNotificationDialog.RedirectUrl = "~/Admin/sanphams.aspx";
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
            Response.Redirect("~/Admin/sanphams.aspx");
        }

        private void FillData()
        {
            try
            {
                Admins vcontroller = new Admins();
                Entities.SanPham vsanpham = new Entities.SanPham();
                Entities.Size vsize = new Entities.Size();
                Entities.SanPham_Size vsanpham_size = new Entities.SanPham_Size();
                string errMsg = string.Empty;
                string[] listid = Convert.ToString(Request.QueryString["ID"]).Split(new char[] { ',' });
                int masp = Convert.ToInt32(listid[0]);
                int masize = Convert.ToInt32(listid[1]);
                vsanpham = vcontroller.getby_sanpham(masp.ToString(), ref errMsg);
                lbltensanpham.Text = vsanpham.TenSP;
                vsize = vcontroller.getby_size_ID(masize.ToString(), ref errMsg);
                lblsize.Text = vsize.Size1;
                vsanpham_size = vcontroller.getby_sanpham_size(masp, masize, ref errMsg);
                txtsoluong.Text = vsanpham_size.Soluong.ToString();
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