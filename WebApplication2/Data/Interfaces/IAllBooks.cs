using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Interfaces
{
    public interface IAllBooks
    {
        IEnumerable<Models.Book> Books { get; }
        IEnumerable<Models.Book> getFavBooks { get; }
        Models.Book getObjectBook(int bookId);
        void RemoveFromFavourite(int bookId);
        void AddToFavourite(int bookId);
    }
}
