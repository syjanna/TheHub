using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TheHub2
{
    public partial class Checkout : System.Web.UI.Page
    {
        public static Cart currCart;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) 
            {
                if (Session["user"] == null || Session["cart"] == null)
                {
                    Response.Redirect("Login.aspx");
                    
                }
                currCart = (Cart)Session["cart"];
                summary_grid.DataSource = currCart.getCartItems();
                summary_grid.DataBind();
            }
        }
        
        protected void order_btn_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            
            SqlCommand com = new SqlCommand("Insert into [dbo].[orders](uname, fullname, address, city, province, postalcode, phone, date) " +
                "values (@uname, @name, @addr, @city, @prov, @postal, @phone, @date); select SCOPE_IDENTITY()", con);
            com.Parameters.AddWithValue("@uname", Session["user"]);
            com.Parameters.AddWithValue("@name", name.Text );
            com.Parameters.AddWithValue("@addr", addr.Text);
            com.Parameters.AddWithValue("@city", city.Text);
            com.Parameters.AddWithValue("@prov", province.Text);
            com.Parameters.AddWithValue("@postal", postal.Text);
            com.Parameters.AddWithValue("@phone", phone.Text);
            com.Parameters.AddWithValue("@date", time);
            con.Open();
            //com.ExecuteNonQuery();

            int orderid = Convert.ToInt32(com.ExecuteScalar());
            Cart currCart = (Cart)Session["cart"];
            foreach (CartItem item in currCart.getCartItems())
            {
                SqlCommand com2;
                if (item.type != "computer") {
                    com2 = new SqlCommand("Insert into [dbo].[OrderDetails](productid, orderid, price, quantity) values" +
                        "(@pid, @orderid, @price, @quant);", con);
                    
                } else
                {
                    com2 = new SqlCommand("Insert into [dbo].[OrderDetails](productid, orderid, price, quantity, ram_id, os_id, drive_id, sound_id, display_id, graphicscard_id, configs) values" +
                        "(@pid, @orderid, @price, @quant, @ram, @os, @drive, @sound, @display, @graphicscard, @configs);", con);
                    com2.Parameters.AddWithValue("@ram", item.ram.id);
                    com2.Parameters.AddWithValue("@os", item.os.id);
                    com2.Parameters.AddWithValue("@drive", item.drive.id);
                    com2.Parameters.AddWithValue("@sound", item.sound.id);
                    com2.Parameters.AddWithValue("@display", item.display.id);
                    com2.Parameters.AddWithValue("@graphicscard", item.graphicscard.id);
                    com2.Parameters.AddWithValue("@configs", item.ram.name + ", " + item.os.name + ", " + item.drive.name + ", " + item.sound.name + ", " + item.display.name + ", " + item.graphicscard.name);

                }
                com2.Parameters.AddWithValue("@pid", item.product.id);
                com2.Parameters.AddWithValue("@orderid", orderid);
                com2.Parameters.AddWithValue("@price", item.price);
                com2.Parameters.AddWithValue("@quant", item.quantity);
                
                com2.ExecuteNonQuery();
            }   

            
            con.Close();
            Session["cart"] = null;
            Response.Redirect("success.html");
        }
    }
}
