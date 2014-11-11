using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shop_quanao.COMM;
using System.Data;

namespace shop_quanao.UserControls
{
    public partial class thanhtoan : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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
                //Sau khi tạo xong thì lưu lại vào session
                Session["cart"] = cart;
            }
            else
            {
                //Lấy thông tin giỏ hàng từ Session["cart"]
                cart = Session["cart"] as DataTable;
            }

            //Hiện thị thông tin giỏ hàng
            //Hiện thị thông tin giỏ hàng
            GridView1.DataSource = cart;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Sửa thông tin giỏ hàng
            string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            TextBox quantity = GridView1.Rows[e.NewSelectedIndex].Cells[2].FindControl("txtQuantity")
                as TextBox;
            //Duyệt qua Giỏ hàng và tăng số lượng
            DataTable cart = Session["cart"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                //Kiểm tra mã sản phẩm phù hợp để gán số lượng khách hàng mua
                if (dr["ID"].ToString() == id)
                {
                    dr["Quantity"] = int.Parse(quantity.Text);
                    break;
                }
            }
            //Lưu lại vào Session
            Session["cart"] = cart;
            //Hiển thị giỏ hàng với thông tin mới
            GridView1.DataSource = cart;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Xóa sản phẩm khỏi giỏ hàng
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //Duyệt qua Giỏ hàng và xóa sản phẩm phù hợp
            DataTable cart = Session["cart"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                //Kiểm tra mã sản phẩm phù hợp để tăng số lượng
                if (dr["ID"].ToString() == id)
                {
                    dr.Delete();
                    break;
                }
            }
            //Lưu lại vào Session
            Session["cart"] = cart;
            //Hiển thị giỏ hàng với thông tin mới
            GridView1.DataSource = cart;
            GridView1.DataBind();
        }

        protected void btndathang_Click(object sender, EventArgs e)
        {
            try
            {
                EndUser vcontrol = new EndUser();

                int mahd = Convert.ToInt32(DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString());
                vcontrol.ThemHD(mahd, txttenkhachhang.Text, txtdiachi.Text, txtsdt.Text, txtemail.Text);
                DataTable cart = Session["cart"] as DataTable; ;
                foreach (DataRow row in cart.Rows)
                {
                    vcontrol.ThemCTHD(mahd, row["ID"].ToString(), row["Size"].ToString(), Convert.ToInt32(row["Quantity"]), Convert.ToDouble(row["Price"]));
                }
                Session["cart"] = null;
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}