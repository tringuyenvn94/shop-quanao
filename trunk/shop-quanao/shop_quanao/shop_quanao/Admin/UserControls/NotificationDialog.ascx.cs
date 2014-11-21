using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin.UserControls
{
    public partial class NotificationDialog : System.Web.UI.UserControl
    {
        public string DialogTitle
        {
            get
            {
                object obj = ViewState["vsDialogTitle"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }
            set { ViewState["vsDialogTitle"] = value; }
        }

        public string MessageContent
        {
            get
            {
                object obj = ViewState["vsMessageContent"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }
            set { ViewState["vsMessageContent"] = value; }
        }

        public int MessageType
        {
            get
            {
                object obj = ViewState["vsMessageType"];
                if (obj == null) { return 0; }
                return Convert.ToInt32(obj);
            }
            set { ViewState["vsMessageType"] = value; }
        }

        public string RedirectUrl
        {
            get
            {
                object obj = ViewState["vsRedirectUrl"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }
            set { ViewState["vsRedirectUrl"] = value; }
        }

        public bool ButtonVisible
        {
            get
            {
                object obj = ViewState["vsButtonVisible"];
                if (obj == null) { return true; }
                return Convert.ToBoolean(obj);
            }
            set { ViewState["vsButtonVisible"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Hide();
            if (!string.IsNullOrEmpty(RedirectUrl)) { Response.Redirect(RedirectUrl); }
        }

        public void Show()
        {
            if (MessageType == 0)
            {
                lblError.Visible = true;
                lblSuccess.Visible = false;
                lblError.Text = MessageContent;
            }
            else
            {
                lblError.Visible = false;
                lblSuccess.Visible = true;
                lblSuccess.Text = MessageContent;
            }

            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }
    }
}