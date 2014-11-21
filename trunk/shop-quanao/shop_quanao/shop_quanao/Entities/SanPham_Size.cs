using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class SanPham_Size
    {

        private int maSP;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private int masize;

        public int Masize
        {
            get { return masize; }
            set { masize = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private int soluongtam;

        public int Soluongtam
        {
            get { return soluongtam; }
            set { soluongtam = value; }
        }
    }
}