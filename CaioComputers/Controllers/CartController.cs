using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaioComputers.Models;

namespace CaioComputers.Controllers
{
    public class CartController : Controller
    {

        private IProductRepo _productRepo;
        public CartController()
        {
            _productRepo = new ProductTest();
        }
        public CartController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public ViewResult Index()
        {
            Cart cart = GetCart();
            ViewBag.PriceTotal = cart.GetPriceTotal();
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            Product product = _productRepo.FindProduct(id);
            
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddProduct(product, 1);
            }
            
            return RedirectToAction("Index","Cart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = _productRepo.FindProduct(id);
            if(product != null)
            {
                var cart = GetCart();
                cart.DeleteProduct(product);
            }

            return RedirectToAction("Index", "Cart");
        }
        public ViewResult Checkout()
        {
            ShippingDetails shippingDetails = new ShippingDetails();


            return View(shippingDetails);
        }

        public ActionResult GetCartTotal()
        {
            var cart = GetCart();
            return PartialView(cart.Total());
        }

        private Cart GetCart()
        {
            var cart = Session["Cart"] as Cart;
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}