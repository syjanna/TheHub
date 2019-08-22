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
    public partial class OrderPage : System.Web.UI.Page
    {
        public static int productid;
        public static Product currComputer;
        public static float currComputerPrice; 
        public static List<Product> rams = new List<Product>();
        public static List<Product> oses = new List<Product>(); 
        public static List<Product> cpus = new List<Product>();
        public static List<Product> drives = new List<Product>();
        public static List<Product> sounds = new List<Product>();
        public static List<Product> displays = new List<Product>();
        public static List<Product> graphicscards = new List<Product>();
        public static List<int> defaultparts = new List<int>();
        public static int old_ramid;
        public static int old_osid;
        public static int old_cpuid;
        public static int old_driveid;
        public static int old_soundid;
        public static int old_displayid;
        public static int old_graphicscardid; 



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currComputer = (Product)Session["computerobject"];
                productid = (int)Session["productid"];
                //System.Windows.Forms.MessageBox.Show(productid.ToString());
                displayName.Text = currComputer.name;

                rams = loadProducts("ram", rams);
                oses = loadProducts("os", oses);
                cpus = loadProducts("cpu", cpus);
                drives = loadProducts("drive", drives);
                sounds = loadProducts("sound", sounds);
                displays = loadProducts("display", displays);
                graphicscards = loadProducts("graphicscard", graphicscards);

                bindDDL(rams, selectRAM);
                bindDDL(oses, selectOS);
                bindDDL(cpus, selectCPU);
                bindDDL(drives, selectDRIVE);
                bindDDL(sounds, selectSOUND);
                bindDDL(displays, selectDISPLAY);
                bindDDL(graphicscards, selectGRAPHICSCARD);



                defaultparts.Clear();
                defaultparts = loadDefaults(defaultparts);
                selectRAM.SelectedValue = defaultparts[0].ToString();
                selectOS.SelectedValue = defaultparts[1].ToString();
                selectCPU.SelectedValue = defaultparts[2].ToString();
                selectDRIVE.SelectedValue = defaultparts[3].ToString();
                selectSOUND.SelectedValue = defaultparts[4].ToString();
                selectDISPLAY.SelectedValue = defaultparts[5].ToString();
                selectGRAPHICSCARD.SelectedValue = defaultparts[6].ToString();
                //System.Windows.Forms.MessageBox.Show(defaultparts[0].ToString());
                old_ramid = defaultparts[0];
                old_osid = defaultparts[1];
                old_cpuid = defaultparts[2];
                old_driveid = defaultparts[3];
                old_soundid = defaultparts[4];
                old_displayid = defaultparts[5];
                old_graphicscardid = defaultparts[6];

                
                currComputerPrice = currComputer.defaultprice;
                displayPrice.Text = "$" + currComputerPrice.ToString("0.00"); 
            }
            //System.Windows.Forms.MessageBox.Show(currentcomputer.name);
            
        }


        public List<Product> loadProducts(string type, List<Product> list)
        {
            list.Clear();
            SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand com = new SqlCommand("select name, productid from Products inner join CompatibleParts on Products.productid = CompatibleParts.partid where type = '" + type + "' and computerid = " + productid, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product newproduct = loadData((Int32)reader["productid"]);
                    list.Add(newproduct); 
                }
            }
            con.Close();
            return list;
        }

        public void bindDDL(List<Product> list, DropDownList ddl)
        {
            ddl.AppendDataBoundItems = true;
            ddl.Items.Clear(); 
            ddl.DataTextField = "name";
            ddl.DataValueField = "id";
            ddl.DataSource = list;
            ddl.DataBind();
        }
        
        public List<int> loadDefaults(List<int> list)
        {
            SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand com = new SqlCommand("select default_ram, default_os, default_cpu, default_drive, default_sound, default_display, default_graphicscard from Computers where productid = " + productid, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add((Int32)reader["default_ram"]);
                    list.Add((Int32)reader["default_os"]);
                    list.Add((Int32)reader["default_cpu"]);
                    list.Add((Int32)reader["default_drive"]);
                    list.Add((Int32)reader["default_sound"]);
                    list.Add((Int32)reader["default_display"]);
                    list.Add((Int32)reader["default_graphicscard"]);
                }
            }
            con.Close();
            return list;
        }

        public Product loadData(int p)
        {
            SqlConnection con = new SqlConnection("Data Source=thehubdbserver.database.windows.net;Initial Catalog=TheHub220190228094728_db;User ID=songyijo;Password=tma3ahosting!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            Product newproduct = new Product();
            SqlCommand com = new SqlCommand("select * from Products where productid=" + p, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newproduct.id = (Int32)reader["productid"];
                    newproduct.name = reader["name"].ToString();
                    newproduct.imgurl = reader["imgurl"].ToString();
                    newproduct.type = reader["type"].ToString();
                    newproduct.defaultprice = (float)reader.GetDouble(4);
                }

            }
            con.Close();
            return newproduct;
        }

        public Product retrievePart(List<Product> list, int pid)
        {
            foreach (Product p in list)
            {
                if (p.id == pid)
                {
                    return p;
                }
            }
            return null;
        }

        public void changePrice(float priceChange)
        {
            currComputerPrice = currComputerPrice + priceChange;
            displayPrice.Text = "$" + (currComputerPrice).ToString("0.00"); 
        }

        protected void changePart(List<Product> partslist, int old_id, int new_id)
        {
            Product old_part = retrievePart(partslist, old_id);
            Product new_part = retrievePart(partslist, new_id);
            float priceChange = new_part.defaultprice - old_part.defaultprice;
            changePrice(priceChange);

        }

        protected void selectRAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_ramid = Convert.ToInt32(selectRAM.SelectedValue);
            changePart(rams, old_ramid, new_ramid); 
            old_ramid = new_ramid;
        }

        protected void selectOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_osid = Convert.ToInt32(selectOS.SelectedValue);
            changePart(oses, old_osid, new_osid);
            old_osid = new_osid;
        }

        protected void selectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_cpuid = Convert.ToInt32(selectCPU.SelectedValue);
            changePart(cpus, old_cpuid, new_cpuid);
            old_cpuid = new_cpuid;
        }

        protected void selectDRIVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_driveid = Convert.ToInt32(selectDRIVE.SelectedValue);
            changePart(drives, old_driveid, new_driveid);
            old_driveid = new_driveid;
        }

        protected void selectSOUND_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_soundid = Convert.ToInt32(selectSOUND.SelectedValue);
            changePart(sounds, old_soundid, new_soundid);
            old_soundid = new_soundid;
        }

        protected void selectDISPLAY_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_displayid = Convert.ToInt32(selectDISPLAY.SelectedValue);
            changePart(displays, old_displayid, new_displayid);
            old_displayid = new_displayid;
        }

        protected void selectGRAPHICSCARD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int new_graphicscardid = Convert.ToInt32(selectGRAPHICSCARD.SelectedValue);
            changePart(graphicscards, old_graphicscardid, new_graphicscardid);
            old_graphicscardid = new_graphicscardid;
        }

        protected void addCart_btn_Click(object sender, EventArgs e)
        {
            /*
            int quantity = Convert.ToInt32(user_quantity.Text);
            double price = quantity * currComputerPrice;
            price = Math.Truncate(price * 100)/100;
            */

            CartItem newitem = new CartItem(currComputer, currComputerPrice, currComputer.imgurl, Convert.ToInt32(user_quantity.Text), 
                "computer", rams[Convert.ToInt32(selectRAM.SelectedIndex)], oses[Convert.ToInt32(selectOS.SelectedIndex)], 
                cpus[Convert.ToInt32(selectCPU.SelectedIndex)], drives[Convert.ToInt32(selectDRIVE.SelectedIndex)], 
                sounds[Convert.ToInt32(selectSOUND.SelectedIndex)], displays[Convert.ToInt32(selectDISPLAY.SelectedIndex)], 
                graphicscards[Convert.ToInt32(selectGRAPHICSCARD.SelectedIndex)]);
            

            if (Session["cart"] == null)
            {
                Cart c = new Cart();
                c.addItem(newitem);
                Session["cart"] = c;
                
            } else
            {
                Cart c = (Cart)Session["cart"];
                c.addItem(newitem);
                Session["cart"] = c;
            }

            msg.Text = "Item was added to cart. Items will remain in cart for 60 minutes.";

        }
    }
    
}