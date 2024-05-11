using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetCategoriesAsync(); // <T>

        Task<Category> GetCategoryByIdAsync(int id);
    }
}
