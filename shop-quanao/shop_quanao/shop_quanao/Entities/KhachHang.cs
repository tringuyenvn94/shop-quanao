using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class KhachHang
    {

        private int maKH;

        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string tendangnhap;

        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        private string matkhau;

        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        private string hoten;

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private int gioitinh;

        public int Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string sodienthoai;

        public string Sodienthoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }
        private bool laadmin;

        public bool Laadmin
        {
            get { return laadmin; }
            set { laadmin = value; }
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}