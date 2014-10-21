<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="shop_quanao.Default" %>

<%@ Register Src="~/UserControls/Listsamphamhot.ascx" TagPrefix="uc" TagName="listsanphamhot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:listsanphamhot id="uclistsanphamhot" runat="server"></uc:listsanphamhot>
</asp:Content>
