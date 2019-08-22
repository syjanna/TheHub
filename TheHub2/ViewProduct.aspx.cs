using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TheHub2
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        public static int productid;
        public static string productconfig;
        public static Product currentcomputer = new Product();

        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productid = (int)Session["productid"];
                LoadComputerInfo();
                Session["computerobject"] = currentcomputer;
            }
            
        }

        private void LoadComputerInfo()
        {
            
            SqlCommand com = new SqlCommand("select * from Products inner join Computers on Products.productid = Computers.productid where Products.productid=" + productid, con);
            
            con.Open();
            SqlDataReader reader = com.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    currentcomputer.name = reader["name"].ToString(); 
                    currentcomputer.defaultprice = (float)reader.GetDouble(4);
                    currentcomputer.imgurl = reader["imgurl"].ToString();
                    currentcomputer.id = productid;
                    productconfig = reader["default_configs"].ToString();

                }
                
            }
            con.Close();
            
            displayName.Text = currentcomputer.name;
            displayPrice.Text = "$" + currentcomputer.defaultprice.ToString();
            displayImage.ImageUrl = currentcomputer.imgurl;
            displayConfigs.Text = productconfig;
        }

        protected void orderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }
    }
}