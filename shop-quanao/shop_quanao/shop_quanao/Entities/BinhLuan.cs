using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class BinhLuan
    {

        private int mabinhluan;

        public int Mabinhluan
        {
            get { return mabinhluan; }
            set { mabinhluan = value; }
        }
        private string tieude;

        public string Tieude
        {
            get { return tieude; }
            set { tieude = value; }
        }
        private string noidung;

        public string Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }
        private DateTime ngayBL;

        public DateTime NgayBL
        {
            get { return ngayBL; }
            set { ngayBL = value; }
        }
        private int maKH;

        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private int maSP;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}