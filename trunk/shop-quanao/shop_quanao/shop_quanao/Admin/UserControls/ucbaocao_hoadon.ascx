<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucbaocao_hoadon.ascx.cs" Inherits="shop_quanao.Admin.UserControls.ucbaocao_hoadon" %>



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
                    <section><label> Tên sản phẩm</label>
                        <div>
                            <asp:Label ID="lblsanpham" runat="server" Text=""></asp:Label>
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
                            Mã Hóa đơn
                        </th>
                        <th scope="col">
                            Tên khách hàng
                        </th>
                        <th scope="col">
                            SĐT
                        </th>
                        <th scope="col">
                            Ngày đặt
                        </th>
                        <th scope="col">
                            Trạng thái
                        </th>
                        <th scope="col">
                            Size SP
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
                                    <%# Eval("mahoadon")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("tenkhachhang")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("sodienthoai")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("ngaydat")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("trangthai")%>
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
                        SelectCommand="select hoadon.mahoadon, tenkhachhang, sodienthoai, size_sp, ngaydat, trangthai, soluong, dongia from hoadon inner join chitiethoadon  on hoadon.mahoadon = chitiethoadon.mahoadon WHERE (chitiethoadon.MaSP = @masanpham)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="masanpham" QueryStringField="ID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </tbody>
            </table>
        </div>
        <div style="text-align: right">
            <asp:Button ID="btnCancel" runat="server" Text="Trở về báo cáo danh thu" CssClass="button"
                OnClick="btnCancel_Click" />
        </div>
    </div>
</div>