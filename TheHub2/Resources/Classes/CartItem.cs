using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheHub2
{
    public class CartItem
    {
        public Product product { get; set; }
        public float price { get; set; }
        public string imgurl { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public Product ram { get; set; }
        public Product os { get; set; }
        public Product cpu { get; set; }
        public Product drive { get; set; }
        public Product sound { get; set; }
        public Product display { get; set; }
        public Product graphicscard { get; set; }

        public CartItem()
        {

        }

        // constructor for parts products
        public CartItem(Product prod, float pr, string img, int qty, string tp)
        {
            product = prod;
            price = pr;
            imgurl = img;
            quantity = qty;
            type = tp;
        }

        // constructor for computer products
        public CartItem(Product prod, float pr, string img, int qty, string tp, Product ram, Product os, Product cpu, Product drive, Product sound, Product display, Product graphicscard)
        {
            product = prod;
            price = pr;
            imgurl = img;
            quantity = qty;
            type = tp;
            this.ram = ram;
            this.os = os;
            this.cpu = cpu;
            this.drive = drive;
            this.sound = sound;
            this.display = display;
            this.graphicscard = graphicscard; 
        }

    }

}