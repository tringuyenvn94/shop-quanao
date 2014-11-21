using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class chitiethoadon
    {
        private string mahoadon;

        public string Mahoadon
        {
            get { return mahoadon; }
            set { mahoadon = value; }
        }
        private int MaSP;

        public int MaSP1
        {
            get { return MaSP; }
            set { MaSP = value; }
        }
        private string size_sp;

        public string Size_sp
        {
            get { return size_sp; }
            set { size_sp = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private decimal dongia;

        public decimal Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
    }
}