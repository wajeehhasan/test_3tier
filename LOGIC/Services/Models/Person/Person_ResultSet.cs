using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Person
{
    public class Person_ResultSet
    {
        public Int64 Id { get; set; } //(PK)
        public String Person_Name { get; set; }
        public String Person_Surname { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Int64 price { get; set; }
        public string pictureUrl { get; set; }
    }
}
