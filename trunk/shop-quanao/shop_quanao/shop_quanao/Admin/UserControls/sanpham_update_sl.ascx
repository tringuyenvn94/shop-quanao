<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sanpham_update_sl.ascx.cs"
    Inherits="shop_quanao.Admin.UserControls.sanpham_update_sl" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<%@ Register Src="~/Admin/UserControls/ConfirmDialog.ascx" TagPrefix="uc" TagName="ConfirmDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Cập nhập số lượng sản phẩm
        </h3>
        <div>
            <p>
                <br />
                Những mục có dấu <span style="color: Red">*</span> là bắt buộc phải nhập</p>
            <fieldset>
                <section><label><span style="color:Red">*</span> Tên sản phẩm:</label>
                    <div>
                        <asp:Label ID="lbltensanpham" runat="server" Text="Label"></asp:Label>   
                    </div>
                </section>
                <section><label><span style="color:Red"></span> Size:</label>
                    <div>
                        <asp:Label ID="lblsize" runat="server" Text="Label"></asp:Label>
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Số lượng:</label>
                    <div>
                        <asp:TextBox ID="txtsoluong" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section>
				    <div>
				        <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="Xác nhận" 
                                Width="80px" onclick="btnSubmit_Click"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Hủy" 
                                Width="80px" onclick="btnCancel_Click"/>
                    </div>
			    </section>
            </fieldset>
        </div>
    </div>
</div>
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Cập nhập số lượng sản phẩm" />
<uc:ConfirmDialog ID="ucConfirmDialog" runat="server" DialogTitle="Cập nhập số lượng sản phẩm" />