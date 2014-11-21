<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="shop_quanao.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>Shop Thời Trang | Đăng nhập</title>
    <!-- Apple iOS and Android stuff -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=no,maximum-scale=1">
    <!-- Google Font and style definitions -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=PT+Sans:regular,bold">
    <link rel="stylesheet" href="css/style.css">
    <!-- include the skins (change to dark if you like) -->
    <link rel="stylesheet" href="css/light/theme.css" id="themestyle">
    <!--[if lt IE 9]>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<link rel="stylesheet" href="css/ie.css">
	<![endif]-->
    <!-- Use Google CDN for jQuery and jQuery UI -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.12/jquery-ui.min.js"></script>
    <!-- Loading JS Files this way is not recommended! Merge them but keep their order -->
    <!-- some basic functions -->
    <script src="js/functions.js"></script>
    <!-- all Third Party Plugins -->
    <script src="js/plugins.js"></script>
    <!-- Whitelabel Plugins -->
    <script src="js/wl_Alert.js"></script>
    <script src="js/wl_Dialog.js"></script>
    <script src="js/wl_Form.js"></script>
    <!-- configuration to overwrite settings -->
    <script src="js/config.js"></script>
    <!-- the script which handles all the access to plugins etc... -->
    <script src="js/login.js"></script>
    <style>
        .button
        {
            margin: 10px 0px 1px 0px;
        }
        
        .rememberbox input
        {
            width: 16px;
        }
    </style>
</head>
<body id="login">
    <header>
		<div id="logo">
			<a href="Default.aspx">Shop Thời Trang</a>
		</div>
	</header>
    <div class="alert info" id="AlertNotification" runat="server" style="display: block;">
        <asp:Label ID="lblAlert" runat="server" />
    </div>
    <section id="content">
	<form id="loginform" runat="server">
		<fieldset>
			<section><label for="username">Tài khoản:</label>					
				<div><asp:TextBox ID="txtUserName" runat="server" Width="100%" autofocus></asp:TextBox></div>
			</section>
			<section><label for="password">Mật khẩu:</label>
				<div><asp:TextBox ID="txtPassword" runat="server" Width="100%" TextMode="Password"></asp:TextBox></div>
			</section>
			<section>
				<div><asp:Button ID="btnSubmit" runat="server" Text="Đăng nhập" CssClass="button" 
                        Width="120px" onclick="btnSubmit_Click"></asp:Button></div>
			</section>
		</fieldset>
	</form>
	</section>
    <footer>Copyright ©  2014</footer>
</body>
</html>

