<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ThanhToan.aspx.cs" Inherits="shop_quanao.ThanhToan" %>

<%@ Register Src="~/UserControls/thanhtoan.ascx" TagPrefix="uc" TagName="thanhtoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:thanhtoan ID="ucthanhtoan" runat="server">
    </uc:thanhtoan>
</asp:Content>
