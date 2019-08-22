using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TheHub2
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imgurl { get; set; }
        public string type { get; set; }
        public float defaultprice { get; set; }

        public Product()
        {

        }

        

    }
}