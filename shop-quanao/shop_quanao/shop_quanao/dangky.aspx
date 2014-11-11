<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="dangky.aspx.cs" Inherits="shop_quanao.dangky" %>

<%@ Register Src="~/UserControls/dangky.ascx" TagPrefix="uc" TagName="dangky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentslide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:dangky ID="ucdangky" runat="server">
    </uc:dangky>
</asp:Content>
