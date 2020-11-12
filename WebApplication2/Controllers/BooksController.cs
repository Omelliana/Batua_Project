using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;
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
        [Route("Books/List")]
        [Route("Books/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Book> books = null;
            string bookCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                books = allBooks.Books.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("horror", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBooks.Books.Where(i => i.Category.categoryName.Equals("horror")).OrderBy(i => i.id);
                } else if (string.Equals("romantic", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBooks.Books.Where(i => i.Category.categoryName.Equals("romantic")).OrderBy(i => i.id);
                }
                bookCategory = category;

                

            }
            var bookObject = new BooksListViewModel
            {
                allBooks = books,
                currCategory = bookCategory
            };

            ViewBag.Title = "Страница с книгами";
            return View(bookObject);
        }
        
        public RedirectToActionResult AddToFav(int id)
        {
            allBooks.AddToFavourite(id);
            return RedirectToAction("List");
        }

    }
}
