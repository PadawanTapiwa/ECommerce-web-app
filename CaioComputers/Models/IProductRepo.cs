using System.Collections.Generic;

namespace CaioComputers.Models
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts();
        void RemoveProduct(int id);
        void SaveChanges();
        Product FindProduct(int id);
        
    }
}