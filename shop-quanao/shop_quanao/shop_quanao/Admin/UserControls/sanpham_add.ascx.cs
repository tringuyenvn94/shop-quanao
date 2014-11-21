using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class sanpham_add : System.Web.UI.UserControl
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
            try
            {

                Admins vcontroller = new Admins();
                string errMsg = string.Empty;
                Entities.SanPham vsanpham = new Entities.SanPham();
                vsanpham.MaSP = COMM.Common.GetID_MaxForInsert("[dbo].[SanPham]", "[MaSP]", "");
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
                int _soluong = 0;
                if (string.IsNullOrEmpty(txtsoluong.Text))
                {
                    _soluong = 0;
                }
                else
                {
                    if (COMM.Common.isInt(txtsoluong.Text))
                    {
                        _soluong = Convert.ToInt32(txtsoluong.Text);
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
                        NotificationMessage("Chưa có hình ảnh cho sản phẩm", 0);
                        return;
                    }
                    vsanpham.Hinhanh = txthinhanh.Text;
                }
                int result = vcontroller.sp_save_sanpham(vsanpham.MaSP, txttensp.Text, vsanpham.Giamua, vsanpham.Giaban, Convert.ToInt32(ddlLoaisanpham.SelectedValue), Convert.ToInt32(ddlChuDe.SelectedValue), Txtthongtin.Text, Convert.ToInt32(ddlgioitinh.SelectedValue), DateTime.Now, vsanpham.Hinhanh, Convert.ToInt32(ddlsize.SelectedValue), _soluong, ref errMsg);
                if (result > 0)
                {
                    if (fulhinhanh.HasFile)
                    {
                        string filename = fulhinhanh.FileName;
                        string path = "~/Img/" + Server.HtmlEncode(fulhinhanh.FileName);
                        fulhinhanh.SaveAs(Server.MapPath(path));
                    }
                    ucNotificationDialog.MessageContent = "Thêm mới sản phẩm  thành công!";
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
                NotificationMessage("Hệ thống gặp sự cố trong quá trình thêm sản phẩm mới!", 0);
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
            Response.Redirect("~/Admin/sanphams.aspx");
        }
    }
}