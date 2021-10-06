using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Person
    {

        public String Person_Name { get; set; }
        public Int64 Id { get; set; }
        public String Person_Surname { get; set; }

        public string name { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Int64 price { get; set; }
        public string pictureUrl { get; set; }


    }
}