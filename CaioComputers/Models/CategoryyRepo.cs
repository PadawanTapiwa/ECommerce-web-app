using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaioComputers.Models;

namespace CaioComputers.Models
{
    public class CategoryRepo : ICategoryRepo
    {
        private CaioDbContext db;

        public CategoryRepo()
        {
            this.db = new CaioDbContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }
    }

    public class CategoryTest : ICategoryRepo
    {
        List<Category> _categories;
        public CategoryTest()
        {
            _categories = new List<Category>()
            {
                new Category(){Name="Camera", Description="Camera Products", Id=1},
                new Category(){Name="Computer", Description="Computer Products", Id=2},
                new Category(){Name="Phone", Description="Phone Products", Id=3},
                new Category(){Name="Electronics", Description="Electronic Products", Id=4}
            };
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public void SaveChanges()
        {
        }
    }
}