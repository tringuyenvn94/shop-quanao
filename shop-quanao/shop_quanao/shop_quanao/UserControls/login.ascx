<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="shop_quanao.UserControls.login" %>
<div class="main-cart-content">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="table-checkout-info">
        <tbody>
            <tr>
                <td class="show-cart-info" colspan="2" style="text-align: center;">
                    <span class="label_intro">ĐĂNG NHẬP SHOP</span>
                </td>
            </tr>
            <tr>
                <td style="width: 200px">
                </td>
                <td valign="top" style="text-align: center;">
                    <div class="customer-exists-info">
                        <table style="width: 400px;" class="table-body" cellspacing="0" cellpadding="0">
                            <tbody id="ttkhachhang">
                                <tr style="height: 35px;">
                                    <td style="text-align: right;">
                                        <span class="required">*</span> Tên đăng nhập:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtusername" runat="server" Style="width: 45%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td style="text-align: right;">
                                        <span class="required">*</span> Mật khẩu:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtmakhau" runat="server" TextMode="Password" validtype="email" Style="width: 45%;"
                                            class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2" style="padding: 4px 0px 5px 3px;">
                                        <asp:Button ID="btndangnhap" runat="server" Text="Đăng nhập" 
                                            onclick="btndangnhap_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</div>
