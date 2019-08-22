using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TheHub2
{
    public partial class ViewParts : System.Web.UI.Page
    {
        public static string partname;
        public static List<Product> partslist = new List<Product>();
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                partname = Request.QueryString["part"].ToString();
                loadData(partname);
                
            }

        }

        public void loadData(string part)
        {
            partslist.Clear();

            
            SqlCommand com = new SqlCommand("select * from Products where type='" + part +"'", con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product newproduct = new Product();
                    newproduct.id = (Int32)reader["productid"];
                    newproduct.name = reader["name"].ToString();
                    newproduct.imgurl = reader["imgurl"].ToString();
                    newproduct.type = reader["type"].ToString();
                    newproduct.defaultprice = (float)reader.GetDouble(4);
                    partslist.Add(newproduct);
                }
                
            }
            PartsGridView.DataSource = partslist;
            PartsGridView.DataBind();
            con.Close();
        }

        protected void addpart_Click(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var textBox = PartsGridView.Rows[index].Cells[3].Controls[1] as TextBox;
            
            CartItem newitem = new CartItem(partslist[index], partslist[index].defaultprice, partslist[index].imgurl, Convert.ToInt32(textBox.Text), partname);

            if (Session["cart"] == null)
            {
                Cart c = new Cart();
                c.addItem(newitem);
                Session["cart"] = c;

            }
            else
            {
                Cart c = (Cart)Session["cart"];
                c.addItem(newitem);
                Session["cart"] = c;
            }
            Response.Redirect("Products.aspx");
            

        }
    }
}