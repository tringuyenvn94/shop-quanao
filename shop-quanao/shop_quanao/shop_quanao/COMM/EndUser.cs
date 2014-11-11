using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace shop_quanao.COMM
{
    public class EndUser : ConnectionDB
    {
        public void ThemHD(int _mahd, string _tenkhachhang, string _diachi, string _sodienthoai, string _email)
        {

            EndUser.Open();


            string now = DateTime.Now.ToString("MM/dd/yyyy");
            string qry = "insert into hoadon values('" + _mahd + "','" + _tenkhachhang + "','" + _diachi + "','" + _sodienthoai + "','" + _email + "','" + now + "','" + now + "','False')";
            SqlCommand cmd = new SqlCommand(qry, EndUser.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            EndUser.Close();
        }

        public void ThemCTHD(int _mahd, string _masanpham, string _size_sp, int _soluong, double _dongia)
        {

            EndUser.Open();
            string qry = "insert into chitiethoadon values('" + _mahd + "','" + _masanpham + "','" + _size_sp + "','" + _soluong + "'," + _dongia + ")";
            SqlCommand cmd = new SqlCommand(qry, EndUser.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            EndUser.Close();
        }



        public DataTable getall_sp_loaisp_gioitinh(int LoaiSP, int Gioitinh)
        {

            EndUser.Open();
            string qry = "SELECT top 20 SanPham.[MaSP], [TenSP], [GiaMua], [GiaBan], [LoaiSP], [ThongTin], [ChuDe], [GioiTinh], [hot], [HinhAnh], [NgayNhapHang],[SoLuong],[Size] FROM [SanPham] inner join SanPham_Size on  SanPham.MaSP = SanPham_Size.MaSP inner join Size on SanPham_Size.MaSize = Size.MaSize  WHERE LoaiSP = " + LoaiSP + "and GioiTinh =" + Gioitinh;
            SqlCommand cmd = new SqlCommand(qry, EndUser.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);

            cmd.Dispose();
            reader.Dispose();

            EndUser.Close();

            return dt;

        }
        public DataTable getall_sp_gioitinh(int Gioitinh)
        {

            EndUser.Open();
            string qry = "SELECT top 20 SanPham.[MaSP], [TenSP], [GiaMua], [GiaBan], [LoaiSP], [ThongTin], [ChuDe], [GioiTinh], [hot], [HinhAnh], [NgayNhapHang],[SoLuong],[Size] FROM [SanPham] inner join SanPham_Size on  SanPham.MaSP = SanPham_Size.MaSP inner join Size on SanPham_Size.MaSize = Size.MaSize  WHERE GioiTinh =" + Gioitinh;
            SqlCommand cmd = new SqlCommand(qry, EndUser.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);

            cmd.Dispose();
            reader.Dispose();

            EndUser.Close();

            return dt;

        }

        public DataTable getall_sp_chude(int _chude)
        {

            EndUser.Open();
            string qry = "SELECT top 20 SanPham.[MaSP], [TenSP], [GiaMua], [GiaBan], [LoaiSP], [ThongTin], [ChuDe], [GioiTinh], [hot], [HinhAnh], [NgayNhapHang],[SoLuong],[Size] FROM [SanPham] inner join SanPham_Size on  SanPham.MaSP = SanPham_Size.MaSP inner join Size on SanPham_Size.MaSize = Size.MaSize  WHERE ChuDe =" + _chude;
            SqlCommand cmd = new SqlCommand(qry, EndUser.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);

            cmd.Dispose();
            reader.Dispose();

            EndUser.Close();

            return dt;

        }
    }
}