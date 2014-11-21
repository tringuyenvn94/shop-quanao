<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true"
    CodeBehind="baocaos.aspx.cs" Inherits="shop_quanao.Admin.baocaos" %>

<%@ Register Src="~/Admin/UserControls/ucbaocao.ascx" TagPrefix="uc" TagName="ucbaocao" %>
<%@ Register Src="~/Admin/UserControls/ucbaocao_hoadon.ascx" TagPrefix="uc" TagName="ucbaocao_hoadon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <uc:ucbaocao ID="ucbaocao" runat="server" />
    <uc:ucbaocao_hoadon ID="ucbaocao_hoadon" runat="server" />
</asp:Content>
