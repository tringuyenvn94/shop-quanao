using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.Entities
{
    public class hoadon
    {

        private string mahoadon;

        public string Mahoadon
        {
            get { return mahoadon; }
            set { mahoadon = value; }
        }
        private string tenkhachhang;

        public string Tenkhachhang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string sodienthoai;

        public string Sodienthoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private DateTime ngaydat;

        public DateTime Ngaydat
        {
            get { return ngaydat; }
            set { ngaydat = value; }
        }
        private DateTime ngaygiao;

        public DateTime Ngaygiao
        {
            get { return ngaygiao; }
            set { ngaygiao = value; }
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}