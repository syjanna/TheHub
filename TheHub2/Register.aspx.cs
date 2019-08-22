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
    
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("AccountPage.aspx");
            }
        }

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            string err_msg = "";

            string check = "select count(*) from [dbo].[users] where uname='" + uname_reg.Text.ToString() + "'";
            
            con.Open();
            SqlCommand com = new SqlCommand(check, con);
            int temp = Convert.ToInt32(com.ExecuteScalar());
            if (uname_reg.Text.Length > 3 && pswd_reg.Text == pswd2_reg.Text && pswd_reg.Text.Length > 7 && temp == 0)
            {
                string ins = "Insert into [dbo].[users](uname, pswd) values('" + uname_reg.Text + "', '" + pswd_reg.Text + "')";
                SqlCommand com2 = new SqlCommand(ins, con);
                com2.ExecuteNonQuery();
                con.Close();
                msg.Text = "Account for " + uname_reg.Text + " has been created.";
            } else
            {
                if (uname_reg.Text.Length < 4)
                {
                    err_msg += "\n Username must be at least 4 characters!";
                }
                if (pswd_reg.Text != pswd2_reg.Text)
                {
                    err_msg += "\n Passwords must match!";
                }
                if (pswd_reg.Text.Length < 8)
                {
                    err_msg += "\n Password must be at least 8 characters!";
                }
                if (temp != 0)
                {
                    err_msg += "\n Username already exists!";
                }
                msg.Text = err_msg;
            }
            
        }
    }
}