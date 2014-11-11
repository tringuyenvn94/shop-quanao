using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace shop_quanao.UserControls
{
    public partial class Listsamphamhot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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
                        Response.Redirect("~/Default.aspx");
                    }
                }
            }

        }
    }
}