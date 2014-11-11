<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Details.aspx.cs" Inherits="shop_quanao.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div class="BoxCenterCenter">
                <div>
                    <img src="<%# Eval("HinhAnh")%>" width="500px" height="500px;" /></div>
                <br />
                <div>
                    <a href='Default.aspx?action=add&amp;id=<%# Eval("MaSP")%>&amp;name=<%# Eval("TenSP")%>&amp;price=<%# Eval("GiaBan")%>&amp;size=<%# Eval("Size")%>'
                        style="vertical-align: middle;">
                        <img src="Img/mua.png" /></a></div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Tên sản phâm:
                    <%# Eval("TenSP")%></div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Giá sản phâm:
                    <%# Eval("GiaBan")%></div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Kích thước:
                    <%# Eval("Size")%></div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Màu: Xanh, Đỏ, Tím, Vàng</div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Chất liệu:
                </div>
                <br />
                <div class="TitelRightBox" style="margin-left: 136px;">
                    Giới thiệu:
                    <%# Eval("TenSP")%></div>
                <br />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shop_quanao %>"
        SelectCommand="SELECT [SanPham].[MaSP], [TenSP], [HinhAnh], [GiaBan], [ThongTin], Size.Size FROM [SanPham] inner join SanPham_Size on SanPham.MaSP = SanPham_Size.MaSP inner join Size on SanPham_Size.MaSize = Size.MaSize WHERE (SanPham.[MaSP] = @MaSP)">
        <SelectParameters>
            <asp:QueryStringParameter Name="MaSP" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
