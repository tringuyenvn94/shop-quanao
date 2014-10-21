<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="shop_quanao.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .glossymenu
        {
            position: relative;
            padding: 0 0 0 5px;
            margin: 0px;
            background-color: #3AB3A9; /*tab background image path*/
            height: 25px;
            list-style: none;
        }
        
        .glossymenu li
        {
            float: left;
            border-right: #FFFFFF 1px groove;
        }
        
        .glossymenu li a
        {
            float: left;
            display: block;
            color: #FFFFFF;
            text-decoration: none;
            font-family: sans-serif;
            font-size: 13px;
            padding: 0 0 0 5px; /*5px = width of menu1*/
            height: 25px;
            line-height: 25px;
            text-align: center;
            cursor: pointer;
        }
        
        .glossymenu li a span
        {
            float: left;
            display: block;
            padding: 0 10px 0 8px; /*Padding of menu items*/
        }
        
        .glossymenu li.current a, .glossymenu li a:hover
        {
            color: #000000;
            background: url(image/menu1.gif) no-repeat bottom; /*left tab image path*/
            background-position: left;
        }
        
        .glossymenu li.current a span, .glossymenu li a:hover span
        {
            color: #000000;
            background: url(image/menu2.gif) no-repeat right bottom; /*right tab image path*/
        }
        a
        {
            text-decoration: none;
        }
        a:hover
        {
            color: #FF9900;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var menu_2 = new Array()
        menu_2[0] = '<a href="#">Sup menu demo 1</a>'
        menu_2[1] = '<a href="#">Sup menu demo 2</a>'
        menu_2[2] = '<a href="#">Sup menu demo 3</a>'
        menu_2[3] = '<a href="#">Sup menu demo 4</a>'

        var menu_3 = new Array()
        menu_3[0] = '<a href="#">Sup menu demo 5</a>'
        menu_3[1] = '<a href="#">Sup menu demo 6</a>'
        menu_3[2] = '<a href="#">Sup menu demo 7</a>'
        function show(id) {
            var men = "menu" + id;
            document.getElementById(men).style.display = 'block';

        }
        function hiden(id) {
            var men = "menu" + id;
            document.getElementById(men).style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1340px; clear: both; margin: auto;">
        <div style="width: 1340px;">
            <ul class="glossymenu">
                <li><a href="#" onmouseover="show(1)" onmouseout="hiden(1)"><span>Trang Nh&#7845;t</span></a></li>
                <li><a href="#" onmouseover="show(2)" onmouseout="hiden(2)"><span>Xă h&#7897;i</span></a></li>
                <li><a href="#" onmouseover="show(3)" onmouseout="hiden(3)"><span>Th&#7871; gi&#7899;i</span></a></li>
                <li><a href="#" onmouseover="show(4)" onmouseout="hiden(4)"><span>Kinh Doanh</span></a></li>
                <li><a href="#" onmouseover="show(5)" onmouseout="hiden(5)"><span>V&#259;n hóa</span></a></li>
                <li><a href="#" onmouseover="show(6)" onmouseout="hiden(6)"><span>Th&#7875; Thao</span></a></li>
                <li><a href="#" onmouseover="show(7)" onmouseout="hiden(7)"><span>Am nhac</span></a></li>
                <li><a href="#" onmouseover="show(8)" onmouseout="hiden(8)"><span>Chuyen la</span></a></li>
                <li><a href="#" onmouseover="show(9)" onmouseout="hiden(9)"><span>Am thuc</span></a></li>
                <li><a href="#" onmouseover="show(10)" onmouseout="hiden(10)"><span>Yeu duong</span></a></li>
                <li><a href="#" onmouseover="show(11)" onmouseout="hiden(11)"><span>Thoi su</span></a></li>
                <li><a href="#" onmouseover="show(12)" onmouseout="hiden(12)"><span>Hau truong</span></a></li>
            </ul>
        </div>
        <div style="background: #d0d8e0; width: 1000px; height: 20px;">
            <div id="menu1" style="display: none;" onmouseover="show(1)" onmouseout="hiden(1)">
                <a href="#">Link demo 1.1</a> <a href="#">Link demo 1.2</a> <a href="#">Link demo 1.3</a>
                <a href="#">Link demo 1.4</a>
            </div>
            <div id="menu2" style="display: none;" onmouseover="show(2)" onmouseout="hiden(2)">
                <a href="#">Link demo 2.1</a> <a href="#">Link demo 2.2</a> <a href="#">Link demo 2.3</a>
                <a href="#">Link demo 2.4</a>
            </div>
            <div id="menu3" style="display: none;" onmouseover="show(3)" onmouseout="hiden(3)">
                <a href="#">Link demo 3.1</a> <a href="#">Link demo 3.2</a> <a href="#">Link demo 3.3</a>
                <a href="#">Link demo 3.4</a>
            </div>
            <div id="menu4" style="display: none;" onmouseover="show(4)" onmouseout="hiden(4)">
                <a href="#">Link demo 4.1</a> <a href="#">Link demo 4.2</a> <a href="#">Link demo 4.3</a>
                <a href="#">Link demo 4.4</a>
            </div>
            <div id="menu5" style="display: none;" onmouseover="show(5)" onmouseout="hiden(5)">
                <a href="#">Link demo 5.1</a> <a href="#">Link demo 5.2</a> <a href="#">Link demo 5.3</a>
                <a href="#">Link demo 5.4</a>
            </div>
            <div id="menu6" style="display: none;" onmouseover="show(6)" onmouseout="hiden(6)">
                <a href="#">Link demo 6.1</a> <a href="#">Link demo 6.2</a> <a href="#">Link demo 6.3</a>
                <a href="#">Link demo 6.4</a>
            </div>
            <div id="menu7" style="display: none;" onmouseover="show(7)" onmouseout="hiden(7)">
                <a href="#">Link demo 7.1</a> <a href="#">Link demo 7.2</a> <a href="#">Link demo 7.3</a>
                <a href="#">Link demo 7.4</a>
            </div>
            <div id="menu8" style="display: none;" onmouseover="show(8)" onmouseout="hiden(8)">
                <a href="#">Link demo 8.1</a> <a href="#">Link demo 8.2</a> <a href="#">Link demo 8.3</a>
                <a href="#">Link demo 8.4</a>
            </div>
            <div id="menu9" style="display: none;" onmouseover="show(9)" onmouseout="hiden(9)">
                <a href="#">Link demo 9.1</a> <a href="#">Link demo 9.2</a> <a href="#">Link demo 9.3</a>
                <a href="#">Link demo 9.4</a>
            </div>
            <div id="menu10" style="display: none;" onmouseover="show(10)" onmouseout="hiden(10)">
                <a href="#">Link demo 10.1</a> <a href="#">Link demo 10.2</a> <a href="#">Link demo
                    10.3</a> <a href="#">Link demo 10.4</a>
            </div>
            <div id="menu11" style="display: none;" onmouseover="show(11)" onmouseout="hiden(11)">
                <a href="#">Link demo 11.1</a> <a href="#">Link demo 11.2</a> <a href="#">Link demo
                    11.3</a> <a href="#">Link demo 11.4</a>
            </div>
            <div id="menu12" style="display: none;" onmouseover="show(12)" onmouseout="hiden(12)">
                <a href="#">Link demo 12.1</a> <a href="#">Link demo 12.2</a> <a href="#">Link demo
                    12.3</a> <a href="#">Link demo 12.4</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
