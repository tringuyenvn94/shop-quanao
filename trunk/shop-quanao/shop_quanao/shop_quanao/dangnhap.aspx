<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="dangnhap.aspx.cs" Inherits="shop_quanao.dangnhap" %>

<%@ Register Src="~/UserControls/login.ascx" TagPrefix="uc" TagName="login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:login ID="uclogin" runat="server">
    </uc:login>
</asp:Content>
