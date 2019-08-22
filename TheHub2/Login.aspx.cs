using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheHub2
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("AccountPage.aspx");
            }
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            string check = "select count(*) from [dbo].[users] where uname='" + uname_login.Text + "' and pswd='" + pswd_login.Text + "'";
            SqlCommand com = new SqlCommand(check, con);
            con.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar());
            //System.Windows.Forms.MessageBox.Show(temp.ToString());
            con.Close();
            if (temp == 1)
            {
                string loggedin = uname_login.Text;
                Session["user"] = loggedin; 
                Response.Redirect("AccountPage.aspx");
            } else
            {
                msg.Text = "Username and/or password does not match!";
                
            }
        }
    }

    // sending emails https://stackoverflow.com/questions/18326738/how-to-send-email-in-asp-net-c-sharp  (for "Forgot password"? option) 
}