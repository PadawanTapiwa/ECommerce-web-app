using System.Collections.Generic;

namespace CaioComputers.Models
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetCategories();
        void SaveChanges();
    }
}