using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheHub2
{
    public partial class ViewCart : System.Web.UI.Page
    {
        public static Cart currCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cart"] != null)
                {
                    currCart = (Cart)Session["cart"];
                    cartitems_grid.DataSource = currCart.getCartItems();
                    cartitems_grid.DataBind();
                    ordertotal.Text = "$" + currCart.getTotal().ToString("0.00");
                } else
                {
                    update_btn.Visible = false;
                    checkout_btn.Visible = false;
                    msg.Text = "Cart is empty!";
                }
                
            }
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            List<int> remove_list = new List<int>();
            
            for (int i = 0; i < cartitems_grid.Rows.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb = (CheckBox)cartitems_grid.Rows[i].FindControl("remove");
                if (cb.Checked) { remove_list.Add(i); }

                TextBox tb = new TextBox();
                tb = (TextBox)cartitems_grid.Rows[i].FindControl("purchasequantity");
                currCart.getCartItemByIndex(i).quantity = Convert.ToInt32(tb.Text.ToString());

            }
            remove_list.Reverse();
            foreach (int i in remove_list)
            {
                currCart.removeItem(i);
            }
            cartitems_grid.DataSource = currCart.getCartItems();
            cartitems_grid.DataBind();
            ordertotal.Text = "$" + currCart.getTotal().ToString("0.00");
        }

        protected void checkout_btn_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null) {
                Response.Redirect("Checkout.aspx");
            } else
            {
                msg.Text = "You must be logged in to checkout!";
            }
        }
    }
}