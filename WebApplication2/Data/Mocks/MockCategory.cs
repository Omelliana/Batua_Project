using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Mocks
{
    public class MockCategory : IBookCategory
    {
        public IEnumerable<Category> allCategories
        {
            get
            {
                return new List<Category> {
                    new Category{categoryName = "horror", desc = "Books that will scare you"},
                    new Category{categoryName = "romantic", desc = "Books that will show true love"},
                };
   
            }
        }
    }
}
