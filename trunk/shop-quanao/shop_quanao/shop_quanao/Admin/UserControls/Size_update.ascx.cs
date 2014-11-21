using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class Size_update : System.Web.UI.UserControl
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
                    Response.Redirect("~/Admin/Sizes.aspx");
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

            if (string.IsNullOrEmpty(txttensize.Text))
            {
                NotificationMessage("tên size không được để trống", 0);
                return;
            }

            ucConfirmDialog.MessageContent = "Bạn có chắc chắn muốn cập nhật size này không?";
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
            Response.Redirect("~/Admin/Sizes.aspx");
        }

        protected void ucConfirmDialog_Yes(object sender)
        {
            ucConfirmDialog.Hide();

            try
            {

                Admins vcontroller = new Admins();
                Entities.Size vsize = new Entities.Size();
                string errMsg = string.Empty;
                vsize.Masize = Convert.ToInt32(lblsize.Text);
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
                ucNotificationDialog.MessageContent = "Hệ thống gặp sự cố trong quá trình cập nhật !";
                ucNotificationDialog.MessageType = 0;
                ucNotificationDialog.Show();
            }
        }

        protected void ucConfirmDialog_No(object sender)
        {
            ucConfirmDialog.Hide();
            Response.Redirect("~/Admin/Sizes.aspx");
        }

        private void FillData()
        {
            try
            {
                Admins vcontroller = new Admins();
                Entities.Size vsize = new Entities.Size();
                string errMsg = string.Empty;
                vsize = vcontroller.getby_size_ID(Request.QueryString["ID"], ref errMsg);
                lblsize.Text = vsize.Masize.ToString();
                txttensize.Text = vsize.Size1;
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