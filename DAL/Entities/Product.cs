using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Int64 price { get; set; }
        public string pictureUrl { get; set; }
    }
}
