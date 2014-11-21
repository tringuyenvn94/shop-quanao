using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shop_quanao.Admin.UserControls
{
    public delegate void YesEventHandler(object sender);
    public delegate void NoEventHandler(object sender);

    public partial class ConfirmDialog : System.Web.UI.UserControl
    {
        public string DialogTitle
        {
            get
            {
                object obj = ViewState["vsDialogTitle"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }

            set
            { ViewState["vsDialogTitle"] = value; }
        }

        public string MessageContent
        {
            get
            {
                object obj = ViewState["vsMessageContent"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }

            set
            { ViewState["vsMessageContent"] = value; }
        }

        public object Key
        {
            get
            {
                object obj = ViewState["vsKey"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }

            set
            { ViewState["vsKey"] = value; }
        }

        public string RedirectUrl
        {
            get
            {
                object obj = ViewState["vsRedirectUrl"];
                if (obj == null) { return string.Empty; }
                return Convert.ToString(obj);
            }

            set
            { ViewState["vsRedirectUrl"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Yes != null) { Yes(this); }
            if (!string.IsNullOrEmpty(RedirectUrl)) { Response.Redirect(RedirectUrl); }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (No != null) { No(this); }
            if (!string.IsNullOrEmpty(RedirectUrl)) { Response.Redirect(RedirectUrl); }
        }

        public event YesEventHandler Yes;
        public event NoEventHandler No;

        public void Show()
        {
            Visible = true;
            lblMsg.Text = MessageContent;
        }

        public void Hide()
        {
            Visible = false;
        }
    }
}