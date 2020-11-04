using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace batuaShop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {
            
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Book.Any())
            {
                content.AddRange(
                    new Book
                    {
                        name = "it",
                        longDesc = "Страшная книга про клоуна",
                        shortDesc = "Книга про клоуна",
                        img = "/img/It_(2017)_poster.jpg",
                        price = 100,
                        favourite = false,
                        Category = Categories["horror"]
                    },
                    new Book
                    {
                        name = "кладбище домашних животных",
                        longDesc = "Кладбище бывает разным!",
                        shortDesc = "Страшная книга про волшебное кладбище",
                        img = "/img/1629832-1085966.jpg",
                        price = 150,
                        favourite = true,
                        Category = Categories["horror"]
                    },
                    new Book
                    {
                        name = "В метре друг от друга",
                        longDesc = "Книга про школьников. Больных школьников",
                        shortDesc = "Книга про любовь",
                        img = "/img/cover1__w220.jpg",
                        price = 50,
                        favourite = false,
                        Category = Categories["romantic"]
                    }

                );
            }
            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{categoryName = "horror", desc = "Books that will scare you"},
                        new Category{categoryName = "romantic", desc = "Books that will show true love"},
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category item in list)
                    {
                        category.Add(item.categoryName, item);
                    }
                }
                return category;
            }
        }

    }
}
