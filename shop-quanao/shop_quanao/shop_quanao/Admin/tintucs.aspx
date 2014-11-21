<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true"
    CodeBehind="tintucs.aspx.cs" Inherits="shop_quanao.Admin.tintucs" %>

<%@ Register Src="~/Admin/UserControls/tintuc_add.ascx" TagPrefix="uc" TagName="tintuc_add" %>
<%@ Register Src="~/Admin/UserControls/tintuc_list.ascx" TagPrefix="uc" TagName="tintuc_list" %>
<%@ Register Src="~/Admin/UserControls/tintuc_update.ascx" TagPrefix="uc" TagName="tintuc_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:tintuc_add ID="uctintuc_add" runat="server" />
    <uc:tintuc_list ID="uctintuc_list" runat="server" />
    <uc:tintuc_update ID="uctintuc_update" runat="server" />
</asp:Content>
