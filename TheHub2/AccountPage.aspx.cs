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
    public partial class AccountPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private DataTable dt = new DataTable(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                string userloggedin = Session["user"].ToString();
                Label1.Text = "Welcome to your account page, " + userloggedin + "!";

                PullData();
            }
        }

        public void PullData()
        {
            string query = "select * from orders where uname='" + Session["user"].ToString() + "' order by orderid desc";
            
            con.Open();
            using (var da = new SqlDataAdapter(query, con))
            {
                da.Fill(dt); 
            }
            userorders.DataSource = dt;
            userorders.DataBind(); 
            con.Close();

        }

        protected void logout_btn_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}