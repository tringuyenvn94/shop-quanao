<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Size_add.ascx.cs" Inherits="shop_quanao.Admin.UserControls.Size_add" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Thêm size mới
        </h3>
        <div>
            <p>
                <br />
                Những mục có dấu <span style="color: Red">*</span> là bắt buộc phải nhập</p>
            <fieldset>
                <section><label><span style="color:Red">*</span> Tên size:</label>
                    <div>
                       <asp:TextBox ID="txttensize" runat="server" Width="200px" ToolTip="" />
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
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Thêm size mới" />
