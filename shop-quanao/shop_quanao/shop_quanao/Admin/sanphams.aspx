<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true"
    CodeBehind="sanphams.aspx.cs" Inherits="shop_quanao.Admin.sanphams" %>

<%@ Register Src="~/Admin/UserControls/sanpham_add.ascx" TagPrefix="uc" TagName="sanpham_add" %>
<%@ Register Src="~/Admin/UserControls/sanpham_list.ascx" TagPrefix="uc" TagName="sanpham_list" %>
<%@ Register Src="~/Admin/UserControls/sanpham_update.ascx" TagPrefix="uc" TagName="sanpham_update" %>
<%@ Register Src="~/Admin/UserControls/sanpham_update_sl.ascx" TagPrefix="uc" TagName="sanpham_update_sl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:sanpham_add ID="ucsanpham_add" runat="server" />
    <uc:sanpham_list ID="ucsanpham_list" runat="server" />
    <uc:sanpham_update ID="ucsanpham_update" runat="server" />
    <uc:sanpham_update_sl ID="ucsanpham_update_sl" runat="server" />
</asp:Content>
