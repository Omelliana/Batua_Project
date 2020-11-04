using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Mocks
{
    public class MockBooks : IAllBooks
    {
        private readonly IBookCategory bookCategory = new MockCategory();

        public IEnumerable<Book> Books { get {
                return new List<Book>
                   {
                       new Book{name = "it", longDesc = "Страшная книга про клоуна",
                           shortDesc = "Книга про клоуна",
                           img = "/img/It_(2017)_poster.jpg",
                           price = 100,
                           favourite = true,
                           Category = bookCategory.allCategories.First(f => f.categoryName == "horror")},
                       new Book{name = "кладбище домашних животных",
                           longDesc = "Кладбище бывает разным!",
                           shortDesc = "Страшная книга про волшебное кладбище",
                           img = "/img/1629832-1085966.jpg",
                           price = 150,
                           favourite = true,
                           Category = bookCategory.allCategories.First(f => f.categoryName == "horror")},
                       new Book{name = "В метре друг от друга",
                           longDesc = "Книга про школьников. Больных школьников",
                           shortDesc = "Книга про любовь",
                           img = "/img/cover1__w220.jpg",
                           price = 50,
                           favourite = false,
                           Category = bookCategory.allCategories.First(f => f.categoryName == "romantic")}
                   };
            }
        }
        public IEnumerable<Book> getFavBooks { get; set; }

        public Book getObjectBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Book removeFromFavourite(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
