<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="XemGioHang.aspx.cs" Inherits="shop_quanao.XemGioHang" %>

<%@ Register Src="~/UserControls/giohang.ascx" TagPrefix="uc" TagName="giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:giohang ID="ucgiohang" runat="server">
    </uc:giohang>
</asp:Content>
