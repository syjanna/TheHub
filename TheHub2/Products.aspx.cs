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
    public partial class Products : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_ComputerGridData();
        }

        private void Load_ComputerGridData()
        {
            con.Open();
            SqlDataAdapter sqa = new SqlDataAdapter("select * from [dbo].[Products] where type='computer'", con);
            DataSet ds = new DataSet();
            sqa.Fill(ds);
            ComputersGridView.DataSource = ds;
            ComputersGridView.DataBind();
            con.Close();
        }
        

        protected void viewproduct_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["productid"] = productid;
            Response.Redirect("ViewProduct.aspx");
        }


    }

    
}