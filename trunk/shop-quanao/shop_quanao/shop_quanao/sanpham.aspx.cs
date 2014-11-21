using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;
using System.Data;

namespace shop_quanao
{
    public partial class sanpham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                giohang();
                if (Request.QueryString["url"] != null)
                {
                    string ulr = Request.QueryString["url"];
                    EndUser vcontrol = new EndUser();
                    switch (ulr)
                    {
                        case "nam":
                            dtlSanPham.DataSource = vcontrol.getall_sp_gioitinh(1);
                            dtlSanPham.DataBind();
                            break;
                        case "nam0":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(0, 1);
                            dtlSanPham.DataBind();
                            break;
                        case "nam1":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(1, 1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nam1";
                            break;
                        case "nam2":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(2, 1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nam2";
                            break;
                        case "nam3":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(3, 1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nam3";
                            break;
                        case "nam4":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(4, 1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nam4";
                            break;
                        case "nu":
                            dtlSanPham.DataSource = vcontrol.getall_sp_gioitinh(0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu0";
                            break;
                        case "nu0":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(0, 0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu0";
                            break;
                        case "nu1":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(1, 0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu1";
                            break;
                        case "nu2":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(2, 0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu2";
                            break;
                        case "nu3":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(3, 0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu3";
                            break;
                        case "nu4":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(5, 0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "nu4";
                            break;
                        case "phukien1":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(6, 1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "pknam";
                            break;
                        case "phukien0":
                            dtlSanPham.DataSource = vcontrol.getall_sp_loaisp_gioitinh(6, 0);
                            dtlSanPham.DataBind();
                            break;
                        case "saleoff":
                            dtlSanPham.DataSource = vcontrol.getall_sp_chude(2);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "saleoff";
                            break;
                        case "new":
                            dtlSanPham.DataSource = vcontrol.getall_sp_chude(1);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "new";
                            break;
                        case "hot":
                            dtlSanPham.DataSource = vcontrol.getall_sp_chude(0);
                            dtlSanPham.DataBind();
                            //Session["LoaiSP"] = "hot";
                            break;
                        case "tk":
                            //string TenSP = Request.QueryString["value"];
                            //dtlSanPham.DataSource = bus.TimKiemSanPham(TenSP);
                            //dtlSanPham.DataBind();
                            break;
                        default:
                            break;

                    }
                }
            }

        }
        public void giohang()
        {
            if (!IsPostBack)
            {
                DataTable cart = new DataTable();
                if (Session["cart"] == null)
                {
                    //Nếu chưa có giỏ hàng, tạo giỏ hàng thông qua DataTable với 4 cột chính
                    //ID (Mã sản phẩm), Name (Tên sản phẩm)
                    //Price (Giá tiền), Quantity (Số lượng)

                    cart.Columns.Add("ID");
                    cart.Columns.Add("Name");
                    cart.Columns.Add("Price");
                    cart.Columns.Add("Quantity");
                    cart.Columns.Add("Size");
                    //Sau khi tạo xong thì lưu lại vào session
                    Session["cart"] = cart;
                }
                else
                {
                    //Lấy thông tin giỏ hàng từ Session["cart"]
                    cart = Session["cart"] as DataTable;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["action"]))
                {
                    if (Request.QueryString["action"] == "add")
                    {
                        string id = Request.QueryString["id"];
                        string name = Request.QueryString["name"];
                        string price = Request.QueryString["price"];
                        string size = Request.QueryString["size"];
                        //Kiểm tra xem đã có sản phẩm trong giỏ hàng chưa ?
                        //Nếu chưa thì thêm bản ghi mới vào giỏ hàng với số lượng Quantity là 1
                        //Nếu có thì tăng quantity lên 1
                        bool isExisted = false;
                        foreach (DataRow dr in cart.Rows)
                        {
                            if (dr["ID"].ToString() == id)
                            {
                                dr["Quantity"] = int.Parse(dr["Quantity"].ToString()) + 1;
                                isExisted = true;
                                break;
                            }
                        }
                        if (!isExisted)//Chưa có sản phẩm trong giỏ hàng
                        {
                            DataRow dr = cart.NewRow();
                            dr["ID"] = id;
                            dr["Name"] = name;
                            dr["Price"] = price;
                            dr["Quantity"] = 1;
                            dr["Size"] = size;
                            cart.Rows.Add(dr);
                        }
                        //Lưu lại thông tin giỏ hàng mới nhất vào session["Cart"]
                        Session["cart"] = cart;
                        //Quay lai trang chu
                        Response.Redirect("~/sanpham.aspx");
                    }
                }
            }
        }
    }
}