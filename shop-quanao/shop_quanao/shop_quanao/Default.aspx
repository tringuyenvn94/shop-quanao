<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="shop_quanao.Default" %>

<%@ Register Src="~/UserControls/Listsamphamhot.ascx" TagPrefix="uc" TagName="listsanphamhot" %>
<%@ Register Src="~/UserControls/slide.ascx" TagPrefix="uc" TagName="slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentslide" runat="server">
    <uc:slide id="ucslide" runat="server">
    </uc:slide>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:listsanphamhot ID="uclistsanphamhot" runat="server"></uc:listsanphamhot>
</asp:Content>
