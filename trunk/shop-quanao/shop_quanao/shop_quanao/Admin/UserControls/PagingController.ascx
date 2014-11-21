<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagingController.ascx.cs" Inherits="shop_quanao.Admin.UserControls.PagingController" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0" style="border: 0px;
    padding-top: 10px; background-color: Transparent;">
    <tr>
        <td style="border: 0px;">
            (Trang
            <asp:Label ID="lblCurrentPage" runat="server">1</asp:Label>
            của
            <asp:Label ID="lblTotalPages" runat="server">1</asp:Label>)
        </td>
        <td style="border: 0px;" valign="top" align="right">
            Trang
            <asp:DropDownList ID="ddPage" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </td>
        <td style="border: 0px;" valign="top" align="right">
            Số bản ghi hiển thị
            <asp:DropDownList ID="ddlRowsPerPage" runat="server" AutoPostBack="true">
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="100">100</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" style="border: 0px;">
            <asp:ImageButton ID="btnFirst" runat="server" Enabled="false" ImageUrl="/Admin/images/sq_br_first_disable.png" />
            <asp:ImageButton ID="btnPrevious" runat="server" Enabled="false" ImageUrl="/Admin/images/sq_br_prev_disable.png" />
            <asp:ImageButton ID="btnNext" runat="server" Enabled="false" ImageUrl="/Admin/images/sq_br_next_disable.png" />
            <asp:ImageButton ID="btnLast" runat="server" Enabled="false" ImageUrl="/Admin/images/sq_br_last_disable.png" />
        </td>
    </tr>
</table>
