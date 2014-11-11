<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="sanpham.aspx.cs" Inherits="shop_quanao.sanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="TitelLeftBoxCenter">
        <asp:Label ID="lblloaisanpham" runat="server" Text=""></asp:Label>
    </div>
    <div class="U3">
    </div>
    <div class="BoxUniversityNews">
        <asp:Repeater ID="dtlSanPham" runat="server">
            <ItemTemplate>
                <div class="BoxUniversityNews2">
                    <div class="BoxImgUniversityNews">
                        <div class="ImgUniversityNews">
                            <a href='../Details.aspx?ID=<%# Eval("MaSP")%>'>
                                <img alt=" <%# Eval("TenSP")%>" src=" <%# Eval("HinhAnh")%>" /></a></div>
                    </div>
                    <div class="BoxTextUniversityNews2">
                        <div>
                            <a href='../Details.aspx?ID=<%# Eval("MaSP")%>' style="font-family: Times New Roman;
                                font-size: 17px; text-align: center;">
                                <%# Eval("TenSP")%></a></div>
                        <div>
                            Giá :
                            <%# Eval("GiaBan")%></div>
                        <div>
                            Kích cỡ :
                            <%# Eval("Size")%></div>
                        <a href='Default.aspx?action=add&amp;id=<%# Eval("MaSP")%>&amp;name=<%# Eval("TenSP")%>&amp;price=<%# Eval("GiaBan")%>&amp;size=<%# Eval("Size")%>'
                            class="bt-dathang add2cart" style="vertical-align: middle;">
                            <img src="Img/mua.png" width="70px" height="30px"></a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
