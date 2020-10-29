using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Models
{
    public class Book
    {
        public int id { set; get; }
        public String name { set; get; }
        public String shortDesc { set; get; }
        public String longDesc { set; get; }
        public String img { set; get; }
        public uint price { set; get; }
        public virtual Category Category{set;get;}
        public int categoryId{set;get;}
        public bool favourite { get; set; }
    }
}
