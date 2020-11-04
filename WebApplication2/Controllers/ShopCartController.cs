using batuaShop.Data.Models;
using batuaShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;

namespace batuaShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllBooks bookRep;
        private readonly ShopCart shopCart;

        public ShopCartController(IAllBooks newBookRep, ShopCart newShopCart)
        {
            bookRep = newBookRep;
            shopCart = newShopCart;
        }

        public ViewResult Index()
        {
            var items = shopCart.getShopItems();
            shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = shopCart
            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = bookRep.Books.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        } 

    }
}
