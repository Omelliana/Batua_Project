using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Models
{
    public class Category {

        public int id {
            set;get;
        }
        public String categoryName {
            set;get;
        }
        public String desc {
            set;get;
        }
        public List<Book> books {
            set;get;
        }
        
    }
}
