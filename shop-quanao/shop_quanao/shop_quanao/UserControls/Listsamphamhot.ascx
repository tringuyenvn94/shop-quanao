<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Listsamphamhot.ascx.cs"
    Inherits="shop_quanao.UserControls.Listsamphamhot" %>
<div class="TitelLeftBoxCenter">
    HÀNG HOT
</div>
<div class="U3">
</div>
<div class="BoxUniversityNews">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div class="BoxUniversityNews2">
                <div class="BoxImgUniversityNews">
                    <div class="ImgUniversityNews">
                        <a href='../Details.aspx?ID=<%# Eval("MaSP")%>'>
                            <img alt=" <%# Eval("TenSP")%>" src=" <%# Eval("HinhAnh")%>" /></a></div>
                </div>
                <div class="BoxTextUniversityNews2">
                    <div>
                        <a href='../Details.aspx?ID=<%# Eval("MaSP")%>' style="font-family: Times New Roman;
                            font-size: 17px; text-align: center;">
                            <%# Eval("TenSP")%></a></div>
                    <div>
                        Giá :
                        <%# Eval("GiaBan")%></div>
                    <div>
                        Kích cỡ :
                        <%# Eval("Size")%></div>
                    <a href='Default.aspx?action=add&amp;id=<%# Eval("MaSP")%>&amp;name=<%# Eval("TenSP")%>&amp;price=<%# Eval("GiaBan")%>&amp;size=<%# Eval("Size")%>'
                        class="bt-dathang add2cart" style="vertical-align: middle;">
                        <img src="Img/mua.png" width="70px" height="30px"></a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shop_quanao %>"
        SelectCommand="SELECT top 12 SanPham.[MaSP], [TenSP], [GiaMua], [GiaBan], [LoaiSP], [ThongTin], [ChuDe], [GioiTinh], [hot], [HinhAnh], [NgayNhapHang],[SoLuong],[Size]
 FROM [SanPham] inner join SanPham_Size on  SanPham.MaSP = SanPham_Size.MaSP inner join Size on SanPham_Size.MaSize = Size.MaSize where SanPham.hot = 1 ">
    </asp:SqlDataSource>
    <%--<div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham3.htm">
                    <img src="Img/anh3.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham3.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo 2 trong 1</a></div>
            <div>
                Giá : 320k + 200k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham4.htm">
                    <img src="Img/anh4.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham4.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun</a></div>
            <div>
                Giá : 260k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham2.htm">
                    <img src="Img/anh2.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham2.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun hình</a></div>
            <div>
                Giá : 360k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham5.htm">
                    <img src="Img/anh5.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham5.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Đầm hoa hồng</a></div>
            <div>
                Giá : 750k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham6.htm">
                    <img src="Img/anh6.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham6.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Đầm ren</a></div>
            <div>
                Giá : 245k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham1.htm">
                    <img alt="Áo thun hình" src="Img/anh1.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham1.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun hình</a></div>
            <div>
                Giá : 360k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham3.htm">
                    <img src="Img/anh3.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham3.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo 2 trong 1</a></div>
            <div>
                Giá : 320k + 200k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham4.htm">
                    <img src="Img/anh4.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham4.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun</a></div>
            <div>
                Giá : 260k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham2.htm">
                    <img src="Img/anh2.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham2.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun hình</a></div>
            <div>
                Giá : 360k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham5.htm">
                    <img src="Img/anh5.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham5.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Đầm hoa hồng</a></div>
            <div>
                Giá : 750k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham6.htm">
                    <img src="Img/anh6.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham6.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Đầm ren</a></div>
            <div>
                Giá : 245k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham1.htm">
                    <img alt="Áo thun hình" src="Img/anh1.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham1.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun hình</a></div>
            <div>
                Giá : 360k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham3.htm">
                    <img src="Img/anh3.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham3.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo 2 trong 1</a></div>
            <div>
                Giá : 320k + 200k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham4.htm">
                    <img src="Img/anh4.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham4.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun</a></div>
            <div>
                Giá : 260k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>
    <div class="BoxUniversityNews2">
        <div class="BoxImgUniversityNews">
            <div class="ImgUniversityNews">
                <a href="Sanpham2.htm">
                    <img src="Img/anh2.png" /></a></div>
        </div>
        <div class="BoxTextUniversityNews2">
            <div>
                <a href="Sanpham2.htm" style="font-family: Times New Roman; font-size: 17px; text-align: center;">
                    Áo thun hình</a></div>
            <div>
                Giá : 360k</div>
            <div>
                Kích cỡ : S L</div>
            <a style="text-align: center;">
                <img src="Img/mua.png" width="70px" height="30px"></a>
        </div>
    </div>--%>
</div>
