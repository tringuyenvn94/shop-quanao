<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="giohang.ascx.cs" Inherits="shop_quanao.UserControls.giohang" %>
<div style="background: #f3f3f3; padding: 10px; margin: -1px; border: 1px solid #fff;
    box-shadow: 0 0 5px #dfdfdf; -moz-box-shadow: 0 0 5px #dfdfdf; -webkit-box-shadow: 0 0 5px #dfdfdf;">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="table-checkout-info">
        <thead>
            <tr>
                <td class="show-cart-info" colspan="2" style="text-align: center;">
                    <span class="label_intro">THÔNG TIN PHIẾU ĐẶT HÀNG</span>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td valign="top">
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                            EnableModelValidation="True" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Mã Sản Phẩm">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Tên Sản Phẩm">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Số Lượng">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Price" HeaderText="Giá Tiền">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Chức Năng">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select">Update</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" OnClientClick="return confirm(&quot;Are u sure ?&quot;)">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                    <div id="cart-total">
                        <table>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
        <%--<tbody>
        <tr>
            <td class="show-cart-info" colspan="2" style="text-align: center;">
                <span class="label_intro">THÔNG TIN KHÁCH HÀNG</span>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div class="customer-exists-info">
                    <table style="width: 100%;" class="table-body" cellspacing="0" cellpadding="0">
                        <tbody id="ttkhachhang">
                            <tr style="height: 35px;">
                                <td style="width: 20%;">
                                    <span class="required">*</span> <strong>Tên khách hàng: </strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttenkhachhang" runat="server" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    <span class="required">*</span> Địa chỉ:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdiachi" TextMode="MultiLine" runat="server" Style="height: 40px;
                                        width: 94.7%" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    <span class="required">*</span> Số điện thoại:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsdt" runat="server" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    <span class="required">*</span> Email:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" validtype="email" Style="width: 95%;" class="trim input easyui-validatebox validatebox-text validatebox-invalid"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    <span class="required">*</span> Thanh toán:
                                </td>
                                <td>
                                    <select id="paymenttype" name="paymenttype" class="trim input" style="width: 49%;
                                        height: 27px;">
                                        <option value="TM">Tiền mặt</option>
                                        <option value="CK">Chuyển khoản</option>
                                        <option value="BK">Thanh toán an toàn qua BAOKIM.VN</option>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    <span class="required">*</span> Nhập mã xác nhận:
                                </td>
                                <td>
                                    <input id="txtCaptchaCheckOut" type="text" class="input" style="width: 30%;">
                                    <input id="imgcaptchaCheckOut" class="captcha-imei easyui-tooltip tooltip-f" title=""
                                        readonly="readonly">
                                    <a href="javascript:void(0)" onclick="RandomCaptchaCheckOut();">
                                        <img src="/images/refresh.png" alt="" title="" class="easyui-tooltip tooltip-f"></a>
                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2" style="padding: 4px 0px 5px 3px;">
                                    <asp:Button ID="btndathang" runat="server" Text="Đặt hàng" OnClick="btndathang_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </tbody>--%>
    </table>
</div>
