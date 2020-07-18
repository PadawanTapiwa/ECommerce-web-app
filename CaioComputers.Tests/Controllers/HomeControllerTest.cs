using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaioComputers;
using CaioComputers.Controllers;
using CaioComputers.Models;
using NUnit.Framework;


namespace CaioComputers.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        IProductRepo productRepo = new ProductTest();
        ICategoryRepo categoryRepo = new CategoryTest();

        [Test]
        public void Index_ReturnsAView()
        {
            HomeController controller = new HomeController(productRepo);

            ViewResult view = controller.Index() as ViewResult;

            Assert.IsNotNull(view);
        }
        public void Index_ReturnsAModel()
        {
            HomeController controller = new HomeController(productRepo);

            ViewResult view = controller.Index() as ViewResult;
            
            Assert.IsNotNull(view.Model);
        }

        [Test]
        public void Product_ReturnsAView()
        {
            HomeController controller = new HomeController(productRepo);

            ViewResult result = controller.Products() as ViewResult;
            
            Assert.IsNotNull(result);

        }

        [TestCase("Camera",1)]
        [TestCase("Computer", 2)]
        [TestCase("Phone", 3)]
        public void Product_GivenACategoryParameter_ReturnsAListOfProductsInACategory(string category, int catId)
        {
            HomeController controller = new HomeController(productRepo);

            ViewResult view = controller.Products(category: category) as ViewResult;
            var products = view.Model as IEnumerable<Product>;
            Assert.AreEqual(products.First().CategoryId, catId);
        }
        

        [Test]
        public void GetCategories_returnsAViewResult()
        {
            HomeController controller = new HomeController(categoryRepo);
            var view = controller.GetCategories() as PartialViewResult;
            Assert.IsNotNull(view);
        }

        [Test]
        public void GetCategories_returnsListOfCategories()
        {
            HomeController controller = new HomeController(categoryRepo);
            var result = controller.GetCategories() as PartialViewResult;
            Assert.IsNotNull(result.Model);
        }


    }
}
