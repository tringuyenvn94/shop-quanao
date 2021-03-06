﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Size_list.ascx.cs" Inherits="shop_quanao.Admin.UserControls.Size_list" %>

<%@ Register Src="~/Admin/UserControls/PagingController.ascx" TagPrefix="uc" TagName="PagingController" %>
<%@ Register Src="~/Admin/UserControls/NotificationDialog.ascx" TagPrefix="uc" TagName="NotificationDialog" %>
<%@ Register Src="~/Admin/UserControls/ConfirmDialog.ascx" TagPrefix="uc" TagName="ConfirmDialog" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Danh sách Size <a class="collapse" title="collapse widget"></a>
        </h3>
        <br />
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
                            Mã size
                        </th>
                        <th scope="col">
                            Tên size
                        </th>
                        <th scope="col">
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                        OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <%# Eval("MaSize")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Size")%>
                                </td>
                                <td style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="cập nhập" CommandName="update" CommandArgument='<%# Eval("MaSize")%>'
                                        CssClass="btn icon small" />
                                    <asp:Button ID="Button2" runat="server" Text="delete" CommandName="delete" CommandArgument='<%# Eval("MaSize")%>'
                                        CssClass="btn icon small" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblFooter" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="2">
                            <uc:PagingController ID="ucDataNavigator" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="text-align: right">
            <asp:Button ID="btnAdd" runat="server" Text="Thêm size" CssClass="button" OnClick="btnAdd_Click" />
        </div>
    </div>
</div>
<uc:ConfirmDialog ID="ucConfirmDialog" runat="server" DialogTitle="Danh sách size" />
<uc:NotificationDialog ID="ucNotificationDialog" runat="server" DialogTitle="Danh sách size" />
