<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true"
    CodeBehind="hoadons.aspx.cs" Inherits="shop_quanao.Admin.hoadons" %>

<%@ Register Src="~/Admin/UserControls/hoadon_list.ascx" TagPrefix="uc" TagName="hoadon_list" %>
<%@ Register Src="~/Admin/UserControls/chitiet_hoadon.ascx" TagPrefix="uc" TagName="chitiet_hoadon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:hoadon_list ID="uchoadon_list" runat="server" />
    <uc:chitiet_hoadon ID="ucchitiet_hoadon" runat="server" />
</asp:Content>
