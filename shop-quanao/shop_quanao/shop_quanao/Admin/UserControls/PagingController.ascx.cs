using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public delegate void FirstPageEventHandler(object sender, DataNavigatorEventArgs e);
    public delegate void LastPageEventHandler(object sender, DataNavigatorEventArgs e);
    public delegate void PreviousPageEventHandler(object sender, DataNavigatorEventArgs e);
    public delegate void NextPageEventHandler(object sender, DataNavigatorEventArgs e);
    public delegate void PageChangedEventHandler(object sender, DataNavigatorEventArgs e);
    public delegate void SizeChangedEventHandler(object sender, DataNavigatorEventArgs e);

    public partial class PagingController : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Method Customize
        public void RefreshControl(int currentPage, int totalPage)
        {

            this.TotalPages = totalPage;
            this.CurrentPage = currentPage;

            ddPage.Items.Clear();

            if (totalPage > 0)
            {
                for (int i = 1; i <= totalPage; i++)
                    ddPage.Items.Add(i.ToString());
                ddPage.SelectedValue = currentPage.ToString();
            }
            else
                ddPage.Items.Add("0");

        }
        #endregion

        //public events
        public event FirstPageEventHandler FirstPage;
        public event LastPageEventHandler LastPage;
        public event PreviousPageEventHandler PreviousPage;
        public event NextPageEventHandler NextPage;
        public event PageChangedEventHandler PageChanged;
        public event SizeChangedEventHandler SizeChanged;

        #region Events in button
        protected void OnPageChangedButton(object sender, EventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(ddPage.SelectedItem.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);
            OnPageChanged(args);
        }

        protected virtual void OnPageChanged(DataNavigatorEventArgs args)
        {
            if (PageChanged != null)
            {
                // Invoke the delegates.
                PageChanged(this, args);
            }
        }

        protected void OnPreviousPageButton(object sender, ImageClickEventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(lblCurrentPage.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);

            SetDropDownPageNumber(args.CurrentPage - 1);

            OnPreviousPage(args);
        }

        protected virtual void OnPreviousPage(DataNavigatorEventArgs args)
        {
            if (PreviousPage != null)
            {
                // Invoke the delegates.
                PreviousPage(this, args);
            }
        }

        protected void OnNextPageButton(object sender, ImageClickEventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(lblCurrentPage.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);

            SetDropDownPageNumber(args.CurrentPage + 1);

            OnNextPage(args);
        }

        protected virtual void OnNextPage(DataNavigatorEventArgs args)
        {
            if (NextPage != null)
            {
                // Invoke the delegates.
                NextPage(this, args);
            }
        }

        protected void OnFirstPageButton(object sender, ImageClickEventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(lblCurrentPage.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);

            SetDropDownPageNumber(1);

            OnFirstPage(args);
        }

        protected virtual void OnFirstPage(DataNavigatorEventArgs args)
        {
            if (FirstPage != null)
            {
                // Invoke the delegates.
                FirstPage(this, args);
            }
        }

        protected void OnLastPageButton(object sender, ImageClickEventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(lblCurrentPage.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);

            SetDropDownPageNumber(args.TotalPages);

            OnLastPage(args);
        }

        protected virtual void OnLastPage(DataNavigatorEventArgs args)
        {
            if (LastPage != null)
            {
                // Invoke the delegates.
                LastPage(this, args);
            }
        }

        protected void OnSizeChanged(object sender, EventArgs e)
        {
            DataNavigatorEventArgs args = new DataNavigatorEventArgs();
            args.CurrentPage = int.Parse(ddPage.SelectedItem.Text);
            args.TotalPages = int.Parse(lblTotalPages.Text);
            SizeChanged(this, args);
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrevious.Click += new System.Web.UI.ImageClickEventHandler(this.OnPreviousPageButton);
            this.btnNext.Click += new System.Web.UI.ImageClickEventHandler(this.OnNextPageButton);
            this.btnFirst.Click += new System.Web.UI.ImageClickEventHandler(this.OnFirstPageButton);
            this.btnLast.Click += new System.Web.UI.ImageClickEventHandler(this.OnLastPageButton);
            this.ddPage.SelectedIndexChanged += new EventHandler(this.OnPageChangedButton);
            this.ddlRowsPerPage.SelectedIndexChanged += new EventHandler(this.OnSizeChanged);
        }
        #endregion

        #region Get/Set Properties
        public int PageSize
        {
            get { return Convert.ToInt32(ddlRowsPerPage.SelectedItem.Value); }
        }

        public int CurrentPage
        {
            get { return int.Parse(lblCurrentPage.Text); }
            set { lblCurrentPage.Text = Convert.ToString(value); }
        }

        public int TotalPages
        {
            get { return int.Parse(lblTotalPages.Text); }
            set { lblTotalPages.Text = Convert.ToString(value); }
        }

        public bool NextButtonEnabled
        {
            get { return btnNext.Enabled; }
            set { btnNext.Enabled = value; }
        }

        public string NextButtonImageUrl
        {
            get { return btnNext.ImageUrl; }
            set { btnNext.ImageUrl = value; }
        }

        public bool PreviousButtonEnabled
        {
            get { return btnPrevious.Enabled; }
            set { btnPrevious.Enabled = value; }
        }

        public string PreviousButtonImageUrl
        {
            get { return btnPrevious.ImageUrl; }
            set { btnPrevious.ImageUrl = value; }
        }

        public bool FirstButtonEnabled
        {
            get { return btnFirst.Enabled; }
            set { btnFirst.Enabled = value; }
        }

        public string FirstButtonImageUrl
        {
            get { return btnFirst.ImageUrl; }
            set { btnFirst.ImageUrl = value; }
        }

        public bool LastButtonEnabled
        {
            get { return btnLast.Enabled; }
            set { btnLast.Enabled = value; }
        }

        public string LastButtonImageUrl
        {
            get { return btnLast.ImageUrl; }
            set { btnLast.ImageUrl = value; }
        }
        #endregion

        private void SetDropDownPageNumber(int iCurrentPage)
        {
            if (ddPage.Items.Count > 0)
                // since SelectedIndex is 0-based, we have to
                // take the current page number and minus 1
                ddPage.SelectedIndex = iCurrentPage - 1;
        }

        private void SetDropDownSize(int currentPageSize)
        {
            if (ddlRowsPerPage.Items.Count > 0)
            {
                switch (currentPageSize)
                {
                    case 10: ddlRowsPerPage.SelectedIndex = 0; break;
                    case 20: ddlRowsPerPage.SelectedIndex = 1; break;
                    case 50: ddlRowsPerPage.SelectedIndex = 2; break;
                    case 100: ddlRowsPerPage.SelectedIndex = 3; break;
                    default: ddlRowsPerPage.SelectedIndex = 0; break;
                }
            }
        }
    }
}