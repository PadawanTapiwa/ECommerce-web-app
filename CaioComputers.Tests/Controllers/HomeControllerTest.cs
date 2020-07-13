using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaioComputers;
using CaioComputers.Controllers;
using CaioComputers.Models;

namespace CaioComputers.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            IProductRepo repo = new ProductTest();
            HomeController controller = new HomeController(repo);

            ViewResult result = controller.Index() as ViewResult;
            

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);            
        }

        [TestMethod]
        public void ProductsTest()
        {
            IProductRepo repo = new ProductTest();
            HomeController controller = new HomeController(repo);
            
            ViewResult result = controller.Products(category:"camera") as ViewResult;
            var prod = result.Model as IEnumerable<Product>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(prod.First().CategoryId,1);
        }
        [TestMethod]
        public void ProductsParameterTest()
        {
            IProductRepo repo = new ProductTest();
            
            HomeController controller = new HomeController(repo);

            ViewResult result = controller.Products(category:"camera") as ViewResult;
            var prod = result.Model as IEnumerable<Product>;

            ViewResult result1 = controller.Products(category:"phone") as ViewResult;
            var prod1 = result.Model as IEnumerable<Product>;


            Assert.AreEqual(prod1.First().CategoryId, 3);
            Assert.AreEqual(prod.First().CategoryId, 1);
        }

        [TestMethod]
        public void GetCategories()
        {
            ICategoryRepo repo = new CategoryTest();
            HomeController controller = new HomeController(repo);

            var result = controller.GetCategories() as ViewResult;
            //var s = result.Model as IEnumerable<string>;

            Assert.IsNotNull(result.Model);
        }

    }
}
