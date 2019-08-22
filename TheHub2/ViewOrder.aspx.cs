using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TheHub2
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        int orderid;
        float total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            orderid = Convert.ToInt32(Request.QueryString["orderid"].ToString());
            PullData();
        }

        public void PullData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from orders where orderid=" + orderid, con) ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();

            SqlCommand cmd2 = new SqlCommand("select * from OrderDetails inner join Products on orderdetails.productid = products.productid where orderid=" + orderid, con);
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                total = total + float.Parse(dr["price"].ToString()) * Convert.ToInt32(dr["quantity"].ToString());
            }
            order_gridview.DataSource = dt2;
            order_gridview.DataBind();
            con.Close();

            ordertotal.Text = total.ToString("0.00");
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            /*List<int> remove_list = new List<int>();

            for (int i = 0; i < order_gridview.Rows.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb = (CheckBox)order_gridview.Rows[i].FindControl("remove");
                if (cb.Checked) { remove_list.Add(i); }

                TextBox tb = new TextBox();
                tb = (TextBox)order_gridview.Rows[i].FindControl("purchasequantity");
                con.Open();
                SqlCommand cmd = new SqlCommand("update OrderDetails" + orderid, con);
                cmd.ExecuteNonQuery();

            }
            remove_list.Reverse();
            foreach (int i in remove_list)
            {
                currCart.cartitems.RemoveAt(i);
            }
            order_gridview.DataSource = currCart.cartitems;
            cartitems_grid.DataBind();
            ordertotal.Text = "$" + currCart.getTotal().ToString("0.00");
            */
        }

        protected void delete_click(object sender, CommandEventArgs e)
        {
            int odid = Convert.ToInt32(e.CommandArgument);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from OrderDetails where orderdetailid=" + odid, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void update_click(object sender, CommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            int index = Convert.ToInt32(arg[0]);
            int odid = Convert.ToInt32(arg[1]);
            var qty_textBox = order_gridview.Rows[index].Cells[3].Controls[1] as TextBox;

            con.Open();
            SqlCommand cmd = new SqlCommand("update OrderDetails set quantity="+Convert.ToInt32(qty_textBox.Text)+" where orderdetailid=" + odid, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void deleteorder_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Orders where orderid=" + orderid, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AccountPage.aspx");
        }
    }
}