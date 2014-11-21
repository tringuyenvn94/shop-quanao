<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sanpham_add.ascx.cs"
    Inherits="shop_quanao.Admin.UserControls.sanpham_add" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Thêm sản phẩm mới
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
                <section><label><span style="color:Red">*</span> Size sản phẩm:</label>
                    <div>
                        <asp:DropDownList ID="ddlsize" runat="server" DataSourceID="SqlDataSource1" 
                            DataTextField="Size" DataValueField="MaSize"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:shop_quanao %>" 
                            SelectCommand="SELECT [MaSize], [Size] FROM [Size]"></asp:SqlDataSource>
                    </div>
                </section>
                <section><label><span style="color:Red"></span>Số lượng sản phẩm:</label>
                    <div>
                        <asp:TextBox ID="txtsoluong"  runat="server" Width="200px" ToolTip="" />
                      
                    </div>
                </section>
                <section><label><span style="color:Red">*</span> Hình ảnh sản phẩm:</label>
                    <div>
                        <asp:FileUpload ID="fulhinhanh" runat="server"></asp:FileUpload>
                    </div>
                    <div>
                        <asp:TextBox ID="txthinhanh" runat="server" Width="400px" ToolTip="" />
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
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Thêm sản phẩm mới" />
