using batuaShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Models;

namespace WebApplication2.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        
    }
}
