using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheHub2
{
    public class Cart
    {
        private List<CartItem> cartitems { get; set; }

        public Cart()
        {
            cartitems = new List<CartItem>();
        }
        
        public List<CartItem> getCartItems()
        {
            return cartitems;
        }

        public void addItem(CartItem item)
        {
            cartitems.Add(item);
        }
        
        public void removeItem(int index)
        {
            cartitems.RemoveAt(index);
        }

        public CartItem getCartItemByIndex(int index)
        {
            return cartitems[index];
        }

        public CartItem getCartItem(int pid)
        {
            foreach (CartItem item in this.cartitems)
            {
                if (item.product.id == pid)
                {
                    return item;
                }
            }
            return null;
        }

        public float getTotal()
        {
            double result = 0;
            foreach (CartItem item in this.cartitems)
            {
                result = result + item.quantity * item.price;
            }
            return (float)result;
        }
    }
}