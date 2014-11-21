using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class sanpham_update : System.Web.UI.UserControl
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
            if (string.IsNullOrEmpty(txttensp.Text))
            {
                NotificationMessage("tên sản phẩm không được để trống", 0);
                return;
            }
            if (string.IsNullOrEmpty(txtgiaban.Text))
            {
                NotificationMessage("Giá bán để trống or không đúng định dạng", 0);
                return;
            }
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
                Entities.SanPham vsanpham = new Entities.SanPham();
                vsanpham.MaSP = Convert.ToInt32(Request.QueryString["ID"]);
                vsanpham.Gioitinh = Convert.ToInt32(ddlgioitinh.SelectedValue);
                if (string.IsNullOrEmpty(txtgiamua.Text))
                {
                    vsanpham.Giamua = 0;
                }
                else
                {
                    if (COMM.Common.isDouble(txtgiamua.Text))
                    {
                        vsanpham.Giaban = Convert.ToDecimal(txtgiamua.Text);
                    }
                    else
                    {
                        NotificationMessage("Không đúng định dạng", 0);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtgiaban.Text))
                {
                    vsanpham.Giaban = 0;
                }
                else
                {
                    if (COMM.Common.isDouble(txtgiaban.Text))
                    {
                        vsanpham.Giaban = Convert.ToDecimal(txtgiaban.Text);
                    }
                    else
                    {
                        NotificationMessage("Không đúng định dạng", 0);
                        return;
                    }
                }
                if (fulhinhanh.HasFile)
                {
                    vsanpham.Hinhanh = "../Img/" + fulhinhanh.FileName;
                }
                else
                {
                    if (string.IsNullOrEmpty(txthinhanh.Text))
                    {
                        vsanpham.Hinhanh = urlhinhanh;
                    }
                    vsanpham.Hinhanh = txthinhanh.Text;
                }
                int result = vcontroller.sp_save_sanpham(vsanpham.MaSP, txttensp.Text, vsanpham.Giamua, vsanpham.Giaban, Convert.ToInt32(ddlLoaisanpham.SelectedValue), Convert.ToInt32(ddlChuDe.SelectedValue), Txtthongtin.Text, Convert.ToInt32(ddlgioitinh.SelectedValue), DateTime.Now, vsanpham.Hinhanh, 0, 0, ref errMsg);
                if (result > 0)
                {
                    if (fulhinhanh.HasFile)
                    {
                        string filename = fulhinhanh.FileName;
                        string path = "~/Img/" + Server.HtmlEncode(fulhinhanh.FileName);
                        fulhinhanh.SaveAs(Server.MapPath(path));
                    }
                    ucNotificationDialog.MessageContent = "cập nhập sản phẩm thành công!";
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
                string errMsg = string.Empty;
                vsanpham = vcontroller.getby_sanpham(Request.QueryString["ID"], ref errMsg);
                txttensp.Text = vsanpham.TenSP;
                Txtthongtin.Text = vsanpham.Thongtin;
                txtgiamua.Text = vsanpham.Giamua.ToString();
                txtgiaban.Text = vsanpham.Giaban.ToString();
                ddlgioitinh.SelectedIndex = vsanpham.Gioitinh;
                ddlChuDe.SelectedIndex = vsanpham.Chude;
                ddlLoaisanpham.SelectedIndex = vsanpham.LoaiSP;
                urlhinhanh = vsanpham.Hinhanh;
                Imgsp.ImageUrl = "~" + vsanpham.Hinhanh.Substring(2);
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