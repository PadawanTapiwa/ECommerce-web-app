using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaioComputers.Models
{
    public class ProductRepo : IProductRepo
    {
        private CaioDbContext db = new CaioDbContext();
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
        }
        public void RemoveProduct(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Product FindProduct(int id)
        {
            return db.Products.SingleOrDefault(prod => prod.Id == id);
        }
    }

    public class ProductTest : IProductRepo
    {
        private List<Product> _products;
        public ProductTest()
        {
            _products = new List<Product>()
            {
                new Product(){Id=1, Name="Apple iPhone 7 32 GB",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=600,IsApproved=true,Stock=100,CategoryId=3,IsHome=true,Image="/image/test/1.jpg"},
                new Product(){Id=2, Name="Apple iPhone 8 32 GB",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=800,IsApproved=false,Stock=200,CategoryId=3,IsHome=true,Image="/image/test/1.jpg"},
                new Product(){Id=3, Name="Apple iPhone X 128 GB",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=1000,IsApproved=false,Stock=120,CategoryId=3,IsHome=true,Image="/image/test/1.jpg"},
                new Product(){Id=4, Name ="Apple iPhone XS 256 GB",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=1200,IsApproved=false,Stock=150,CategoryId=3,IsHome=true,Image="/image/test/1.jpg"},
                new Product(){Id=5, Name="Asus Zenbook Ux333fn",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=800,IsApproved=true,Stock=130,CategoryId=2,IsHome=true,Image="/image/test/2.jpg"},
                new Product(){Id=6, Name="Asus Zenbook Ux433fn",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=850,IsApproved=true,Stock=140,CategoryId=2,IsHome=true,Image="/image/test/2.jpg"},
                new Product(){Id=7, Name="Asus Zenbook Ux331fn",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=700,IsApproved=true,Stock=160,CategoryId=2,IsHome=true,Image="/image/test/2.jpg"},
                new Product(){Id=8, Name="Canon Eos 1200D",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=400,IsApproved=true,Stock=50,CategoryId=1,IsHome=true,Image="/image/test/3.jpg"},
                new Product(){Id=9, Name="Canon Eos 100D",Description="Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.",Price=200,IsApproved=true,Stock=60,CategoryId=2,IsHome=false,Image="/image/test/2.jpg"},

            };
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product FindProduct(int id)
        {
            return _products.FirstOrDefault(prod => prod.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void RemoveProduct(int id)
        {
            var product = _products.First(prod => prod.Id == id);
            _products.Remove(product);
        }

        public void SaveChanges()
        {
        }
    }


}