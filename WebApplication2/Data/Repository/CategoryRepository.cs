using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace batuaShop.Data.Repository
{
    public class CategoryRepository : IBookCategory
    {

        private readonly AppDbContent appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> allCategories => appDbContent.Category;

    }
}
