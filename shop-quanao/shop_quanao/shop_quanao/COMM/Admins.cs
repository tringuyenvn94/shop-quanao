using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shop_quanao.Entities;
using System.Data;
using System.Data.SqlClient;

namespace shop_quanao.COMM
{
    public class Admins
    {
        public KhachHang getby_tk_khachhang_ID(string _makh, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from khachhang where  MaKH like  N'" + _makh + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                KhachHang obj = new KhachHang();
                obj = (KhachHang)CBO.FillObject(dr, typeof(KhachHang));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Size getby_size_ID(string _ma_size, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from Size where  MaSize like  N'" + _ma_size + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                Size obj = new Size();
                obj = (Size)CBO.FillObject(dr, typeof(Size));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPham_Size getby_sanpham_size(int _masp, int _ma_size, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from SanPham_Size where  MaSize =  " + _ma_size + "and MaSP =" + _masp;
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                SanPham_Size obj = new SanPham_Size();
                obj = (SanPham_Size)CBO.FillObject(dr, typeof(SanPham_Size));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPham getby_sanpham_ID(string _ma_sp, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from [dbo].[SanPham] where  [MaSP] like  N'" + _ma_sp + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                SanPham obj = new SanPham();
                obj = (SanPham)CBO.FillObject(dr, typeof(SanPham));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KhachHang getby_tk_khachhang(string _tentaikhoan, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from khachhang where  tendangnhap like  N'" + _tentaikhoan + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                KhachHang obj = new KhachHang();
                obj = (KhachHang)CBO.FillObject(dr, typeof(KhachHang));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int capnhap_tt_khachhang(string _tendangnhap, bool _trangthai, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@tendangnhap", _tendangnhap);
                i = i + 1;
                prms[i] = new SqlParameter("@trangthai", _trangthai);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("dbo.sp_trangthai_khachhang", ref prms, 3, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public DataTable getall_khachhang_page(bool _laadmin, int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[5];
                prms[i] = new SqlParameter("@laadmin", _laadmin);
                i = i + 1;
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_khachhang_page]", ref prms, 4, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public int Login_khachhang(bool _laadmin, string _username, string _password, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[5];
                prms[i] = new SqlParameter("@laadmin", _laadmin);
                i = i + 1;
                prms[i] = new SqlParameter("@username", _username);
                i = i + 1;
                prms[i] = new SqlParameter("@password", _password);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("dbo.sp_login_khachhang", ref prms, 4, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public int save_khachhang(KhachHang vkhachhang, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[12];
                prms[i] = new SqlParameter("@khachhangid", vkhachhang.MaKH);
                i = i + 1;
                prms[i] = new SqlParameter("@tendangnhap", vkhachhang.Tendangnhap);
                i = i + 1;
                prms[i] = new SqlParameter("@matkhau", vkhachhang.Matkhau);
                i = i + 1;
                prms[i] = new SqlParameter("@hoten", vkhachhang.Hoten);
                i = i + 1;
                prms[i] = new SqlParameter("@gioitinh", vkhachhang.Gioitinh);
                i = i + 1;
                prms[i] = new SqlParameter("@diachi", vkhachhang.Diachi);
                i = i + 1;
                prms[i] = new SqlParameter("@emai", vkhachhang.Email);
                i = i + 1;
                prms[i] = new SqlParameter("@sodienthoai", vkhachhang.Sodienthoai);
                i = i + 1;
                prms[i] = new SqlParameter("@laadmin", vkhachhang.Laadmin);
                i = i + 1;
                prms[i] = new SqlParameter("@trangthai", vkhachhang.Trangthai);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("dbo.sp_save_khachhang", ref prms, 11, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public int save_Size(Size vsize, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@MaSize", vsize.Masize);
                i = i + 1;
                prms[i] = new SqlParameter("@Size", vsize.Size1);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("[dbo].[sp_save_Size]", ref prms, 3, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public int delete_Size(int _ma_size, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[3];
                prms[i] = new SqlParameter("@MaSize", _ma_size);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("[dbo].[sp_delete_Size]", ref prms, 2, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public int duyet_hoadon(string _mahoadon, bool _trangthai, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@mahoadon", _mahoadon);
                i = i + 1;
                prms[i] = new SqlParameter("@trangthai", _trangthai);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("dbo.sp_duyet_hoadon", ref prms, 3, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public Entities.SanPham getby_sanpham(string _masanpham, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from sanpham where MaSP like  N'" + _masanpham + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                Entities.SanPham obj = new Entities.SanPham();
                obj = (Entities.SanPham)CBO.FillObject(dr, typeof(Entities.SanPham));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getall_hoadon_page(int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_hoadon_page]", ref prms, 3, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public DataTable getall_Size_page(int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_Size_page]", ref prms, 3, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public DataTable getall_chitiet_hd(string _mahoadon, ref string errMsg)
        {
            try
            {
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new System.Data.SqlClient.SqlParameter("@mahoadon", _mahoadon);
                DataTable dtTon_VatTu = null;
                dtTon_VatTu = SQLExecute.LoadDataFromDB("[dbo].[sp_getall_chitiet_hd]", "tmpData", ref errMsg, CommandType.StoredProcedure, prms, 1);
                return dtTon_VatTu;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw ex;
            }
        }

        public hoadon getby_hoadon(string _mahodon, ref string errMsg)
        {
            try
            {
                string sqlstr = "select * from hoadon where  mahoadon like  N'" + _mahodon + "'";
                IDataReader dr = SQLExecute.getIDataReader(sqlstr, ref errMsg);
                hoadon obj = new hoadon();
                obj = (hoadon)CBO.FillObject(dr, typeof(hoadon));
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getall_danhthu(int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_danhthu]", ref prms, 3, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public DataTable getall_danhthu_para(DateTime _ngaydat, int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[5];
                prms[i] = new SqlParameter("@ngaydat", _ngaydat);
                i = i + 1;
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_danhthu_para]", ref prms, 4, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public DataTable getall_tintuc_page(int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_tintuc_page]", ref prms, 3, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public int sp_save_sanpham(int _masp, string _tensp, decimal _giamua, decimal _giaban, int _loaisp, int _chude, string _thongtin, int _gioitinh, DateTime _ngaynhap, string _hinhanh, int _masize, int _soluong, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[14];
                prms[i] = new SqlParameter("@MaSP", _masp);
                i = i + 1;
                prms[i] = new SqlParameter("@TenSP", _tensp);
                i = i + 1;
                prms[i] = new SqlParameter("@GiaMua", _giamua);
                i = i + 1;
                prms[i] = new SqlParameter("@GiaBan", _giaban);
                i = i + 1;
                prms[i] = new SqlParameter("@LoaiSP", _loaisp);
                i = i + 1;
                prms[i] = new SqlParameter("@ChuDe", _chude);
                i = i + 1;
                prms[i] = new SqlParameter("@ThongTin", _thongtin);
                i = i + 1;
                prms[i] = new SqlParameter("@GioiTinh", _gioitinh);
                i = i + 1;
                prms[i] = new SqlParameter("@NgayNhapHang", _ngaynhap);
                i = i + 1;
                prms[i] = new SqlParameter("@HinhAnh", _hinhanh);
                i = i + 1;
                prms[i] = new SqlParameter("@MaSize", _masize);
                i = i + 1;
                prms[i] = new SqlParameter("@SoLuong", _soluong);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("[dbo].[sp_save_sanpham]", ref prms, 13, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public DataTable getall_sanpham_page(int _pageIndex, int _pageSize, ref int _rowCount, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                SqlParameter[] prms = new SqlParameter[4];
                prms[i] = new SqlParameter("@PageNumber", _pageIndex);
                i = i + 1;
                prms[i] = new SqlParameter("@PageSize", _pageSize);
                i = i + 1;
                prms[i] = new SqlParameter("@outrowcount", SqlDbType.Int, 3);
                prms[i].Direction = ParameterDirection.Output;

                DataTable tbl = SQLExecute.LoadDataFromDBPage("[dbo].[sp_getall_sanpham_page]", ref prms, 3, ref errMsg, ref _rowCount);

                return tbl;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public int save_tintuc(tintuc vtintuc, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[11];
                prms[i] = new SqlParameter("@matintuc", vtintuc.Matintuc);
                i = i + 1;
                prms[i] = new SqlParameter("@teude", vtintuc.Teude);
                i = i + 1;
                prms[i] = new SqlParameter("@mota", vtintuc.Mota);
                i = i + 1;
                prms[i] = new SqlParameter("@noidung", vtintuc.Noidung);
                i = i + 1;
                prms[i] = new SqlParameter("@anh", vtintuc.Anh);
                i = i + 1;
                prms[i] = new SqlParameter("@nguoidang", vtintuc.Nguoidang);
                i = i + 1;
                prms[i] = new SqlParameter("@nguoitao", vtintuc.Nguoitao);
                i = i + 1;
                prms[i] = new SqlParameter("@trangthai", vtintuc.Trangthai);
                i = i + 1;
                prms[i] = new SqlParameter("@ngaydang", vtintuc.Ngaydang);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("[dbo].[sp_save_tintuc]", ref prms, 10, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

        public int update_soluong_sp(int _masp, int _ma_size, int _soluong, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                int result = 0;
                SqlParameter[] prms = new SqlParameter[5];
                prms[i] = new SqlParameter("@MaSP", _masp);
                i = i + 1;
                prms[i] = new SqlParameter("@MaSize", _ma_size);
                i = i + 1;
                prms[i] = new SqlParameter("@SoLuong", _soluong);
                i = i + 1;
                prms[i] = new SqlParameter("@outreturn", SqlDbType.Int, 1);
                prms[i].Direction = ParameterDirection.Output;

                result = SQLExecute.ExcuteSPOutput("[dbo].[sp_update_soluong_sp]", ref prms, 4, ref errMsg, "@outreturn");

                return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }
        }

    }
}