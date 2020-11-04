using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace batuaShop.Data.Repository
{
    public class BookRepository : IAllBooks
    {

        private AppDbContent appDbContent;

        public BookRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Book> Books => appDbContent.Book.Include(b => b.Category);

        public IEnumerable<Book> getFavBooks => appDbContent.Book.Where(p => p.favourite).Include(c => c.Category);

        public Book getObjectBook(int bookId) => appDbContent.Book.FirstOrDefault(p => p.id == bookId);

        public Book removeFromFavourite(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
