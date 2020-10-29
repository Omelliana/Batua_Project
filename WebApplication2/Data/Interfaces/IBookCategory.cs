using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Interfaces
{
    public interface IBookCategory
    {
        IEnumerable<Models.Category> allCategories { get; }

    }
}
