using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class Size_add : System.Web.UI.UserControl
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

            if (string.IsNullOrEmpty(txttensize.Text))
            {
                NotificationMessage("tên size không được để trống", 0);
                return;
            }
            try
            {
                Admins vcontroller = new Admins();
                Entities.Size vsize = new Entities.Size();
                string errMsg = string.Empty;
                vsize.Masize = COMM.Common.GetID_MaxForInsert("[dbo].[Size]", "[MaSize]", "");
                vsize.Size1 = txttensize.Text;
                int result = vcontroller.save_Size(vsize, ref errMsg);
                if (result > 0)
                {
                    ucNotificationDialog.MessageContent = "Thêm mới size thành công!";
                    ucNotificationDialog.MessageType = 1;
                    ucNotificationDialog.RedirectUrl = "~/Admin/Sizes.aspx";
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
            Response.Redirect("~/Admin/Sizes.aspx");
        }
    }
}