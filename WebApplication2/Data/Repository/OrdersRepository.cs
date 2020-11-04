using batuaShop.Data.Interfaces;
using batuaShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace batuaShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {

        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.dateTime = DateTime.Now;
            appDbContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    bookId = el.book.id,
                    orderId = order.id,
                    price = el.book.price
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();
        }



    }
}
