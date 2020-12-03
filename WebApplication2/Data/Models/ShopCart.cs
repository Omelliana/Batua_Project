using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace batuaShop.Data.Models
{
    public class ShopCart
    {

        private readonly AppDbContent appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }


        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        public void AddToCart(Book book)
        {
            var listItems = getShopItems();
            bool found = false;
            ShopCartItem foundItem = null;
            foreach (var item in listItems)
            {
                if (item.book.id == book.id)
                {
                    item.count++;
                    foundItem = item;
                    found = true;
                }
            }
            if (!found)
            {
                this.appDbContent.ShopCartItem.Add(new ShopCartItem
                {
                    shopCartId = ShopCartId,
                    book = book,
                    price = book.price,
                    count = 1

                });
            }
            else
            {
                this.appDbContent.ShopCartItem.Update(foundItem);
            }
            appDbContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems()
        {
            return appDbContent.ShopCartItem.Where(c => c.shopCartId == ShopCartId).Include(s => s.book).ToList();
        }
    }
}
