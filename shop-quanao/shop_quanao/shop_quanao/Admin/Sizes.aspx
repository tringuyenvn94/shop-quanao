<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true"
    CodeBehind="Sizes.aspx.cs" Inherits="shop_quanao.Admin.Sizes" %>

<%@ Register Src="~/Admin/UserControls/Size_add.ascx" TagPrefix="uc" TagName="Size_add" %>
<%@ Register Src="~/Admin/UserControls/Size_list.ascx" TagPrefix="uc" TagName="Size_list" %>
<%@ Register Src="~/Admin/UserControls/Size_update.ascx" TagPrefix="uc" TagName="Size_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:Size_add ID="ucSize_add" runat="server" />
    <uc:Size_list ID="ucSize_list" runat="server" />
    <uc:Size_update ID="ucSize_update" runat="server" />
</asp:Content>
