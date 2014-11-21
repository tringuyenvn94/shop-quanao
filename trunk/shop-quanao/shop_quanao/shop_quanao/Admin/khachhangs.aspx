<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="khachhangs.aspx.cs" Inherits="shop_quanao.Admin.khachhangs" %>

<%@ Register Src="~/Admin/UserControls/khachhang_list.ascx" TagPrefix="uc" TagName="khachhang_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:khachhang_list ID="uckhachhang_list" runat="server" />
</asp:Content>
