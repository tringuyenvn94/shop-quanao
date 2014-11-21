<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="user_add.ascx.cs" Inherits="shop_quanao.Admin.UserControls.user_add" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Thêm User mới
        </h3>
        <div>
            <p>
                <br />
                Những mục có dấu <span style="color: Red">*</span> là bắt buộc phải nhập</p>
            <fieldset>
                <section><label><span style="color:Red">*</span> Tên Đăng nhập:</label>
                    <div>
                       <asp:TextBox ID="txttendangnhap" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Mật Khẩu:</label>
                    <div>
                        <asp:TextBox ID="txtmatkhau" TextMode="Password" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Email:</label>
                    <div>
                        <asp:TextBox ID="txtemail" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Giới tính:</label>
                    <div>
                        <asp:DropDownList ID="ddlgioitinh" runat="server">
                        <asp:ListItem Text="Nam" Selected="True" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Nữ" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Họ tên:</label>
                    <div>
                        <asp:TextBox ID="txthoten" runat="server" Width="200px" ToolTip="" />
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Địa chỉ:</label>
                    <div>
                        <asp:TextBox ID="txtdiachi" TextMode="MultiLine" runat="server" Width="400px" ToolTip="" />
                      
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Số điện thoại:</label>
                    <div>
                        <asp:TextBox ID="txtsdt" runat="server" Width="200px" ToolTip="" />
                         
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
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Thêm User mới" />
