using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class tintuc
    {
        private int matintuc;

        public int Matintuc
        {
            get { return matintuc; }
            set { matintuc = value; }
        }
        private string teude;

        public string Teude
        {
            get { return teude; }
            set { teude = value; }
        }
        private string mota;

        public string Mota
        {
            get { return mota; }
            set { mota = value; }
        }
        private string noidung;

        public string Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }
        private string anh;

        public string Anh
        {
            get { return anh; }
            set { anh = value; }
        }
        private string nguoidang;

        public string Nguoidang
        {
            get { return nguoidang; }
            set { nguoidang = value; }
        }
        private string nguoitao;

        public string Nguoitao
        {
            get { return nguoitao; }
            set { nguoitao = value; }
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private bool tinhot;

        public bool Tinhot
        {
            get { return tinhot; }
            set { tinhot = value; }
        }
        private DateTime ngaydang;

        public DateTime Ngaydang
        {
            get { return ngaydang; }
            set { ngaydang = value; }
        }
        private string matakey;

        public string Matakey
        {
            get { return matakey; }
            set { matakey = value; }
        }
        private string metatile;

        public string Metatile
        {
            get { return metatile; }
            set { metatile = value; }
        }
    }
}