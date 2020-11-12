using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;
using batuaShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace batuaShop.Controllers
{
    public class OneBookController : Controller
    {
        private readonly IAllBooks allBooks;

        public OneBookController(IAllBooks allBooks)
        {
            this.allBooks = allBooks;
        }

        public ViewResult GetOneBook(int id)
        {
            var oneBook = new OneBookViewModel
            {
                book = allBooks.getObjectBook(id)
            };
            return View(oneBook);
        }

    }
}
