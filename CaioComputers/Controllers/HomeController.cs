using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaioComputers.Models;
using Microsoft.Ajax.Utilities;

namespace CaioComputers.Controllers
{
    public class HomeController : Controller
    {
        ICategoryRepo categoryRepo;
        IProductRepo productRepo;
        public HomeController(IProductRepo prodRepo, ICategoryRepo categoryRepo)
        {
            this.productRepo = prodRepo;
            this.categoryRepo = categoryRepo;
        }
        public HomeController(IProductRepo prodRepo)
        {
            this.productRepo = prodRepo;
        }
        public HomeController(ICategoryRepo catrepo)
        {
            this.categoryRepo = catrepo;
        }
        public HomeController()
        {
            categoryRepo = new CategoryTest();
            this.productRepo = new ProductTest();
        }



        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Product> products = productRepo.GetProducts();
            return View(products);
        }


        public ActionResult Products(string search = "search for..", string category="all")
        {
            IEnumerable<Product> products = productRepo.GetProducts();

            if(search != "search for..")
            {
                products = products
                .Where(prod => prod.Name.Contains(search) || prod.Name.StartsWith(search, ignoreCase: true, null));

            }

            products = ProductsByCategory(category, products);

            ViewBag.Search = search;
            return View(products);
        }

        private IEnumerable<Product> ProductsByCategory(string category, IEnumerable<Product> products)
        {

            switch(category)
            {

                case "Camera":
                    return products.Where(prod => prod.CategoryId == 1);
                    
                case "Computer":
                    return products.Where(prod => prod.CategoryId == 2);
                    
                case "Phone":
                    return products.Where(prod => prod.CategoryId == 3);
                    
                case "Electronics":
                    return products.Where(prod => prod.CategoryId == 4);
                default:
                    return products;

            }

        }

        public ActionResult Details(int id)
        {

            Product product = productRepo.FindProduct(id);

            return View(product);
        }

        public ActionResult GetCategories()
        {
            var categories = categoryRepo.GetCategories();
            
            return PartialView(categories);
        }















        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
