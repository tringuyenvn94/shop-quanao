using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;

namespace shop_quanao.Admin.UserControls
{
    public partial class tintuc_list : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        { ucDataNavigator.CurrentPage = 1; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack && Visible)
            {
                ucNotificationDialog.Hide();
                ucConfirmDialog.Hide();
                FillData(1);
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Repeater1.Items.Count == 0)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = e.Item.FindControl("lblFooter") as Label;
                    lblFooter.Text = "<tr>" +
                        "<td colspan='4' style='tex-align:center;font-weight:bold'>Không có dữ liệu</td>" +
                        "</tr>";
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("update"))
            {
                Response.Redirect("~/Admin/tintucs.aspx?module=update&ID=" + e.CommandArgument);
            }
            //if (e.CommandName.ToLower().Equals("update"))
            //{
            //    ucConfirmDialog.MessageContent = "Bạn có chắc chắn kết thúc khuyến mại của sản phẩm này?";
            //    ucConfirmDialog.Key = e.CommandArgument;
            //    ucConfirmDialog.Show();
            //}
        }

        private void NotificationMessage(string _MessageContent, int _MessageType)
        {
            ucNotificationDialog.MessageContent = _MessageContent;
            ucNotificationDialog.MessageType = _MessageType;
            ucNotificationDialog.Show();
            return;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/tintucs.aspx?module=add");
        }

        private void FillData(int pageIndex)
        {

            int pageSize = ucDataNavigator.PageSize;
            int rowCount = 0;
            Admins vcontroller = new Admins();

            string errMsg = string.Empty;
            try
            {

                Repeater1.DataSource = vcontroller.getall_tintuc_page(pageIndex, pageSize, ref rowCount, ref errMsg);
                PreparePaging(pageIndex, pageSize, rowCount);
                Repeater1.DataBind();
            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally
            {
                //vpublishers.Dispose();
                vcontroller = null;

            }
        }

        #region Navigator Button Controller

        private void PreparePaging(int pageIndex, int pageSize, int rowCount)
        {
            int numOfPage;

            lblTotal.Text = rowCount.ToString("#,###");

            if (rowCount == 0)
            {
                numOfPage = 0;
                lblTotal.Text = "0";
                ucDataNavigator.Visible = false;
            }
            else if (rowCount <= pageSize)
            {
                numOfPage = 1;
                ucDataNavigator.Visible = false;
            }
            else
            {
                ucDataNavigator.Visible = true;

                if (rowCount % pageSize == 0)
                {
                    numOfPage = rowCount / pageSize;
                }
                else
                {
                    numOfPage = rowCount / pageSize + 1;
                }
            }

            //Khởi tạo lại PageController
            if (numOfPage == 0)
                ucDataNavigator.RefreshControl(0, numOfPage);
            else if (pageIndex <= numOfPage)
                ucDataNavigator.RefreshControl(pageIndex, numOfPage);
            else
                ucDataNavigator.RefreshControl(1, numOfPage);
            //Thiết lập Enable và Disable các nút di chuyển trang
            EnableDisableButtons(numOfPage);

        }

        protected void PageChanged(object sender, DataNavigatorEventArgs e)
        {
            ucDataNavigator.CurrentPage = e.CurrentPage;
            FillData(ucDataNavigator.CurrentPage);
            EnableDisableButtons(e.TotalPages);
        }

        protected void PageSizeChanged(object sender, DataNavigatorEventArgs e)
        {
            ucDataNavigator.CurrentPage = e.CurrentPage;
            FillData(ucDataNavigator.CurrentPage);
            EnableDisableButtons(e.TotalPages);
        }

        protected void FirstPage(object sender, DataNavigatorEventArgs e)
        {
            // Decrement the current page index.
            if (e.CurrentPage > 1)
            {
                ucDataNavigator.CurrentPage = 1;
                // Get the data for the DataGrid.
                FillData(ucDataNavigator.CurrentPage);
                EnableDisableButtons(e.TotalPages);
            }
        }

        protected void PreviousPage(object sender, DataNavigatorEventArgs e)
        {
            // Decrement the current page index.
            if (e.CurrentPage > 1)
            {
                ucDataNavigator.CurrentPage--;
                // Get the data for the DataGrid.
                FillData(ucDataNavigator.CurrentPage);
                EnableDisableButtons(e.TotalPages);
            }
        }

        protected void NextPage(object sender, DataNavigatorEventArgs e)
        {
            // Decrement the current page index.
            if (e.CurrentPage <= e.TotalPages)
            {
                ucDataNavigator.CurrentPage++;
                // Get the data for the DataGrid.
                FillData(ucDataNavigator.CurrentPage);
                EnableDisableButtons(e.TotalPages);
            }
        }

        protected void LastPage(object sender, DataNavigatorEventArgs e)
        {
            // Decrement the current page index.
            if (e.CurrentPage <= e.TotalPages)
            {
                ucDataNavigator.CurrentPage = e.TotalPages;
                // Get the data for the DataGrid.
                FillData(ucDataNavigator.CurrentPage);
                EnableDisableButtons(e.TotalPages);
            }
        }

        private void EnableDisableButtons(int iTotalPages)
        {
            // Should we disable the first link?
            ucDataNavigator.FirstButtonEnabled = (ucDataNavigator.CurrentPage == 1) || (ucDataNavigator.CurrentPage == 0) ? false : true;
            ucDataNavigator.FirstButtonImageUrl = (ucDataNavigator.CurrentPage == 1) || (ucDataNavigator.CurrentPage == 0) ? "~/Admin/images/sq_br_first_disable.png" : "~/Admin/images/sq_br_first.png";
            // Should we disable the previous link?
            ucDataNavigator.PreviousButtonEnabled = (ucDataNavigator.CurrentPage == 1) || (ucDataNavigator.CurrentPage == 0) ? false : true;
            ucDataNavigator.PreviousButtonImageUrl = (ucDataNavigator.CurrentPage == 1) || (ucDataNavigator.CurrentPage == 0) ? "~/Admin/images/sq_br_prev_disable.png" : "~/Admin/images/sq_br_prev.png";
            // Should we enable the next link?
            ucDataNavigator.NextButtonEnabled = (ucDataNavigator.CurrentPage < iTotalPages) ? true : false;
            ucDataNavigator.NextButtonImageUrl = (ucDataNavigator.CurrentPage < iTotalPages) ? "~/Admin/images/sq_br_next.png" : "~/Admin/images/sq_br_next_disable.png";
            // Should we enable the last link?
            ucDataNavigator.LastButtonEnabled = (ucDataNavigator.CurrentPage < iTotalPages) ? true : false;
            ucDataNavigator.LastButtonImageUrl = (ucDataNavigator.CurrentPage < iTotalPages) ? "~/Admin/images/sq_br_last.png" : "~/Admin/images/sq_br_last_disable.png";
        }


        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            //this.lstdivUserRef.SelectedIndexChanged += new EventHandler(lstdivUserRef_SelectedIndexChanged);
            this.ucDataNavigator.FirstPage += new FirstPageEventHandler(this.FirstPage);
            this.ucDataNavigator.PreviousPage += new PreviousPageEventHandler(this.PreviousPage);
            this.ucDataNavigator.NextPage += new NextPageEventHandler(this.NextPage);
            this.ucDataNavigator.LastPage += new LastPageEventHandler(this.LastPage);
            this.ucDataNavigator.PageChanged += new PageChangedEventHandler(this.PageChanged);
            this.ucDataNavigator.SizeChanged += new SizeChangedEventHandler(this.PageSizeChanged);
            this.ucConfirmDialog.Yes += new YesEventHandler(ucConfirmDialog_Yes);
            this.ucConfirmDialog.No += new NoEventHandler(ucConfirmDialog_No);
            this.Init += new EventHandler(this.Page_Init);
        }

        #endregion


        #region Confirm Dialog Button Controller
        protected void ucConfirmDialog_Yes(object sender)
        {
            ucConfirmDialog.Hide();
            //DM_NuocSanXuat_Controller vnuocsanxuat = new DM_NuocSanXuat_Controller();
            //string errMsg = string.Empty;
            //try
            //{
            //    int result = vnuocsanxuat.delete_dm_nuocsanxuat(Convert.ToString(ucConfirmDialog.Key), ref  errMsg);

            //    if (result > 0)
            //    {
            //        ucNotificationDialog.MessageContent = "Bản ghi đã được xóa thành công!";
            //        ucNotificationDialog.MessageType = 1;
            //        ucNotificationDialog.RedirectUrl = "~/Admin/NuocSanXuats.aspx";
            //        ucNotificationDialog.Show();
            //    }
            //    else
            //    {
            //        if (result == -1) { ucNotificationDialog.MessageContent = "Bản ghi không tồn tại!<br/>Vui lòng kiểm tra lại."; }
            //        else { ucNotificationDialog.MessageContent = "Hệ thống gặp sự cố!<br/>Vui lòng liên hệ @ để được hỗ trợ."; }

            //        ucNotificationDialog.MessageType = 0;
            //        ucNotificationDialog.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.Message);
            //    ucNotificationDialog.MessageContent = "Hệ thống gặp sự cố!<br/>Vui lòng liên hệ @ để được hỗ trợ.";
            //    ucNotificationDialog.MessageType = 0;
            //    ucNotificationDialog.Show();
            //}
            //finally
            //{
            //    vnuocsanxuat = null;
            //}
        }

        protected void ucConfirmDialog_No(object sender) { ucConfirmDialog.Hide(); }
        #endregion
    }
}