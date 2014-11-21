using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class SanPham
    {

        private int maSP;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        private decimal giamua;

        public decimal Giamua
        {
            get { return giamua; }
            set { giamua = value; }
        }
        private decimal giaban;

        public decimal Giaban
        {
            get { return giaban; }
            set { giaban = value; }
        }
        private int loaiSP;

        public int LoaiSP
        {
            get { return loaiSP; }
            set { loaiSP = value; }
        }
        private int chude;

        public int Chude
        {
            get { return chude; }
            set { chude = value; }
        }
        private string thongtin;

        public string Thongtin
        {
            get { return thongtin; }
            set { thongtin = value; }
        }
        private int gioitinh;

        public int Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private DateTime ngaynhaphang;

        public DateTime Ngaynhaphang
        {
            get { return ngaynhaphang; }
            set { ngaynhaphang = value; }
        }
        private string hinhanh;

        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
        }
        private bool hot;

        public bool Hot
        {
            get { return hot; }
            set { hot = value; }
        }
    }
}