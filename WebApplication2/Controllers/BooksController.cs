using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks allBooks;
        private readonly IBookCategory allCategories;

        public BooksController(IAllBooks allBooks, IBookCategory bookCategory)
        {
            this.allBooks = allBooks;
            this.allCategories = bookCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с книгами";
            BooksListViewModel obj = new BooksListViewModel();
            obj.allBooks = allBooks.Books;
            return View(obj);
        }

    }
}
