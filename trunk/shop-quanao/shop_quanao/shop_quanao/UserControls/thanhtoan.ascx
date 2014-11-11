<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="thanhtoan.ascx.cs" Inherits="shop_quanao.UserControls.thanhtoan" %>
<div class="main-cart-content">
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
        <tbody>
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
        </tbody>
    </table>
    <%-- <table id="table-waiting_label" style="display: none;" width="100%">
        <tbody>
            <tr>
                <td style="font-size: 16px; color: red; padding-left: 10px; padding-top: 5px;">
                    <p>
                        Vui lòng đợi .............</p>
                </td>
            </tr>
        </tbody>
    </table>
    <table id="view-checkout-info" style="display: none;" width="100%">
        <tbody>
            <tr>
                <td>
                    <p class="checkout-success-label">
                        Cám ơn quý khách đã đặt mua hàng tại: <span style="color: Blue; text-decoration: underline;
                            font-size: 13px;">http://dienthoaionline.vn</span></p>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                        <legend class="cart-info-title"><strong>» Thông tin khách hàng</strong></legend>
                        <table cellspacing="0" cellpadding="0" id="review-customer-info" class="table-body"
                            width="100%">
                            <tbody>
                                <tr style="height: 30px;">
                                    <td style="width: 100px;">
                                        <strong>Khách hàng: </strong>
                                    </td>
                                    <td>
                                        <span id="sFullName"></span>
                                    </td>
                                </tr>
                                <tr style="height: 30px;">
                                    <td>
                                        Địa chỉ:
                                    </td>
                                    <td>
                                        <span id="sAddress"></span>
                                    </td>
                                </tr>
                                <tr style="height: 30px;">
                                    <td>
                                        Điện thoại:
                                    </td>
                                    <td>
                                        <span id="sTelephone"></span>
                                    </td>
                                </tr>
                                <tr style="height: 30px;">
                                    <td>
                                        Email:
                                    </td>
                                    <td>
                                        <span id="sEmail"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                        <legend class="cart-info-title"><strong>» Thông tin sản phẩm</strong></legend>
                        <table style="clear: both; width: 100%; font: 12px arial;" id="view-cart-detail"
                            class="table-list-card-detail table-body">
                            <thead>
                                <tr style="border-bottom: 1px dotted #CCCCCC; border-top: 1px dotted #CCCCCC;">
                                    <th class="name">
                                        Tên sản phẩm
                                    </th>
                                    <th class="quantity" style="width: 10%">
                                        Số lượng
                                    </th>
                                    <th class="price" style="width: 20%">
                                        Đơn giá
                                    </th>
                                    <th class="total" style="width: 20%">
                                        Thành tiền
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                            <tfoot>
                                <tr style="border-bottom: 1px dotted #cccccc;">
                                    <td align="right">
                                        Tổng tiền:&nbsp;
                                    </td>
                                    <td align="right">
                                        <span id="sQuantity"></span>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="right">
                                        <span id="sTotal"></span>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td>
                    <p style="margin: 0px; font: 13px 'lucida grande', tahoma, verdana, arial, sans-serif;
                        color: #F70; font-weight: bold;">
                        Quý khách vui lòng kiểm tra địa chỉ email để biết thêm chi tiết đơn hàng. Xin cảm
                        ơn.</p>
                </td>
            </tr>
        </tbody>
    </table>--%>
</div>
