<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucbaocao.ascx.cs" Inherits="shop_quanao.Admin.UserControls.ucbaocao" %>
<%@ Register Src="~/Admin/UserControls/PagingController.ascx" TagPrefix="uc" TagName="PagingController" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<%@ Register Src="~/Admin/UserControls/ConfirmDialog.ascx" TagPrefix="uc" TagName="ConfirmDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            báo cáo danh thu sản phẩm <a class="collapse" title="collapse widget"></a>
        </h3>
        <br />
        <div>
            &nbsp;Tiêu chí tìm kiếm:
            <div>
                <fieldset>
                    <section><label> ngày làm hóa đơn</label>
                        <div>
                            <asp:TextBox ID="txtsearch" runat="server" Width="200px"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblngaydinhdang" runat="server" Text="ngày/tháng/nămg"></asp:Label>
                        </div>
                    </section>
                    <section>
			            <div>
			                <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Thống kê" 
                                    Width="80px" onclick="btnSearch_Click"/>                            
                        </div>
		            </section>
                </fieldset>
            </div>
        </div>
        <div>
            &nbsp;Tổng số bản ghi:
            <asp:Label ID="lblTotal" runat="server" Text="" Font-Bold="True"></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <table class="table" cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            Mã sản phẩm
                        </th>
                        <th scope="col">
                            Tên sản phẩm
                        </th>
                        <th scope="col">
                            Số lượng bán
                        </th>
                        <th scope="col">
                            Tổng giá bán
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                        OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <%# Eval("masanpham")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("tensanpham")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("soluong")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("danhthu")%>
                                </td>
                                <td style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="danh sách hóa đơn" CommandName="view"
                                        CommandArgument='<%# Eval("masanpham")%>' CssClass="btn icon small" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblFooter" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="4">
                            <uc:PagingController ID="ucDataNavigator" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
<uc:ConfirmDialog ID="ucConfirmDialog" runat="server" DialogTitle=" báo cáo danh thu sản phẩm" />
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle=" báo cáo danh thu sản phẩm" />
