using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TheHub2
{
    public partial class Feedback : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Feedback](feedback, date) values(@feedback, @date)", con);
            cmd.Parameters.AddWithValue("@feedback", feedback_box.Text);
            cmd.Parameters.AddWithValue("@date", time);
            cmd.ExecuteNonQuery();
            con.Close();
            msg.Text = "Thank you. Your feedback has been submitted.";
        }
    }
}