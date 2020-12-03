using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Models;

namespace batuaShop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Book book { get; set; }
        public uint price { get; set; }
        public uint count { get; set; }

        public String shopCartId { get; set; }
    }
}
