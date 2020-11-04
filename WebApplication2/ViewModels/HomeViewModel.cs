using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Models;

namespace batuaShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> favBooks { get; set; }
    }
}
