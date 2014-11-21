<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="shop_quanao.Admin.users" %>
<%@ Register Src="~/Admin/UserControls/user_add.ascx" TagPrefix="uc" TagName="user_add" %>
<%@ Register Src="~/Admin/UserControls/user_list.ascx" TagPrefix="uc" TagName="user_list" %>
<%@ Register Src="~/Admin/UserControls/user_update.ascx" TagPrefix="uc" TagName="user_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:user_add ID="ucuser_add" runat="server" />
    <uc:user_list ID="ucuser_list" runat="server" />
    <uc:user_update ID="ucuser_update" runat="server" />
</asp:Content>