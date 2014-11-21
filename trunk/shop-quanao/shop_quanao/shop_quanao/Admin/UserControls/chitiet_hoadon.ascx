<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chitiet_hoadon.ascx.cs"
    Inherits="shop_quanao.Admin.UserControls.chitiet_hoadon" %>
<div class="widgets ui-sortable">
    <div class="widget sortable table" style="opacity: 1;">
        <h3 class="handle">
            Chi tiết hóa đơn <a class="collapse" title="collapse widget"></a>
        </h3>
        <br />
        <div>
            &nbsp;Thông tin hóa đơn:
            <div>
                <fieldset>
                    <section><label> Tên khách hàng</label>
                        <div>
                            <asp:TextBox ID="txttenkhachhang" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                    <section><label> Địa chỉ khách hàng</label>
                        <div>
                            <asp:TextBox ID="txtdiachi" TextMode="MultiLine" runat="server" Width="400px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                    <section><label> Số điện thoại</label>
                        <div>
                            <asp:TextBox ID="txtsdt" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                    <section><label> Email</label>
                        <div>
                            <asp:TextBox ID="txtemail" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                    <section><label> Ngày Đặt</label>
                        <div>
                            <asp:TextBox ID="txtngaydat" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                    <section><label> Ngày giao</label>
                        <div>
                            <asp:TextBox ID="txtngaygiao" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </div>
                    </section>
                </fieldset>
            </div>
        </div>
        <div>
            <table class="table" cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            Mã sản phẩm
                        </th>
                        <th scope="col">
                            Tên sản phẩm
                        </th>
                        <th scope="col">
                            Size sản phẩm
                        </th>
                        <th scope="col">
                            Số lượng
                        </th>
                        <th scope="col">
                            Đơn giá
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <%# Eval("MaSP")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("TenSP")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("size_sp")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("soluong")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("dongia")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblFooter" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shop_quanao %>"
                        SelectCommand="SELECT [mahoadon], [sanpham].TenSP,[chitiethoadon].MaSP, chitiethoadon.size_sp , [chitiethoadon].[soluong], [dongia] FROM [chitiethoadon] inner join [sanpham] on [chitiethoadon].MaSP = [sanpham].MaSP WHERE ([mahoadon] = @mahoadon)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="mahoadon" QueryStringField="ID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </tbody>
            </table>
        </div>
        <div style="text-align: right">
            <asp:Button ID="btnCancel" runat="server" Text="Trở về danh sách hóa đơn" CssClass="button"
                OnClick="btnCancel_Click" />
        </div>
    </div>
</div>
