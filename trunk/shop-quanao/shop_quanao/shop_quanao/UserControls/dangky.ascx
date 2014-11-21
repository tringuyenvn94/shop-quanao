<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dangky.ascx.cs" Inherits="shop_quanao.UserControls.dangky" %>
<div class="main-cart-content">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="table-checkout-info">
        <tbody>
            <tr>
                <td class="show-cart-info" colspan="2" style="text-align: center;">
                    <span class="label_intro">ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG</span>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="customer-exists-info">
                        <table style="width: 100%;" class="table-body" cellspacing="0" cellpadding="0">
                            <tbody id="ttkhachhang">
                                <tr style="height: 35px;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> <strong>Tên đăng nhập: </strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtusername" runat="server" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> mật khẩu:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtmatkhau" TextMode="Password" runat="server" Style="width: 95%;"
                                            class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> <strong>Tên khách hàng: </strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttenkhachhang" runat="server" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px; width: 95%;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> Giới tính:
                                    </td>
                                    <td style="text-align: left; margin-left: 5px">
                                        <asp:DropDownList ID="ddlgioitinh" runat="server">
                                            <asp:ListItem Value="1" Selected="True"> Nam</asp:ListItem>
                                            <asp:ListItem Value="0"> Nữ</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; text-align: left;">
                                        <span class="required">*</span> Địa chỉ:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdiachi" TextMode="MultiLine" runat="server" Style="height: 40px;
                                            width: 94.7%" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> Số điện thoại:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtsdt" runat="server" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td style="text-align: left;">
                                        <span class="required">*</span> Email:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtemail" runat="server" validtype="email" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2" style="padding: 4px 0px 5px 3px;">
                                        <asp:Button ID="btndangky" runat="server" Text="Đăng ký" 
                                            onclick="btndangky_Click" />
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
