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
    public class HomeController : Controller
    {
        private IAllBooks bookRep;

        public HomeController(IAllBooks newBookRep)
        {
            bookRep = newBookRep;
        }

        public ViewResult Index()
        {
            var homeBook = new HomeViewModel
            {
                favBooks = bookRep.getFavBooks
            };
            return View(homeBook);
        }

        public RedirectToActionResult RemoveFromFav(int id)
        {
            bookRep.RemoveFromFavourite(id);
            return RedirectToAction("Index");
        }

    }
}
