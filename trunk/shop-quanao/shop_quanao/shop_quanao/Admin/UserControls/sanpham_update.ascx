<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sanpham_update.ascx.cs"
    Inherits="shop_quanao.Admin.UserControls.sanpham_update" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<%@ Register Src="~/Admin/UserControls/ConfirmDialog.ascx" TagPrefix="uc" TagName="ConfirmDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Cập nhập sản phẩm
        </h3>
        <div>
            <p>
                <br />
                Những mục có dấu <span style="color: Red">*</span> là bắt buộc phải nhập</p>
            <fieldset>
                <section><label><span style="color:Red">*</span> Tên sản phẩm:</label>
                    <div>
                       <asp:TextBox ID="txttensp" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red"></span> Giá mua:</label>
                    <div>
                        <asp:TextBox ID="txtgiamua" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Giá bán:</label>
                    <div>
                        <asp:TextBox ID="txtgiaban" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Chủ đề sản phẩm:</label>
                    <div>
                        <asp:DropDownList ID="ddlChuDe" runat="server" >
                            <asp:ListItem Value="0" Selected = "True">HOT</asp:ListItem>
                            <asp:ListItem Value="1">Khuyến mãi</asp:ListItem>
                            <asp:ListItem Value="2">Mới</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Loại sản phẩm:</label>
                    <div>
                         <asp:DropDownList ID="ddlLoaisanpham" runat="server" >
                            <asp:ListItem Value="0" Selected = "True">Áo thun</asp:ListItem>
                            <asp:ListItem Value="1">Áo sơ mi</asp:ListItem>
                            <asp:ListItem Value="2">Áo khoác</asp:ListItem>
                            <asp:ListItem Value="3">Quần Jean</asp:ListItem>
                            <asp:ListItem Value="4">Quần Kaki</asp:ListItem>
                            <asp:ListItem Value="5">Váy</asp:ListItem>
                            <asp:ListItem Value="6">Phụ Kiện</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </section>
                <section><label><span style="color:Red"></span> Thông tin sản phẩm:</label>
                    <div>
                        <asp:TextBox ID="Txtthongtin" runat="server" Width="400px" TextMode="MultiLine" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Giới tính:</label>
                    <div>
                        <asp:DropDownList ID="ddlgioitinh" runat="server">
                            <asp:ListItem Text="Nam" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Nữ" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Hình ảnh sản phẩm:</label>
                    <div>
                        <asp:FileUpload ID="fulhinhanh" runat="server"></asp:FileUpload>
                    </div>
                    <div>
                        <asp:TextBox ID="txthinhanh" runat="server" Width="400px" ToolTip="" />
                    </div>
                    <div>
                        <asp:Image ID="Imgsp" runat="server"></asp:Image>
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
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Cập nhập sản phẩm" />
<uc:ConfirmDialog ID="ucConfirmDialog" runat="server" DialogTitle="Cập nhập sản phẩm" />
