using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CaioComputers.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines;

        public Cart()
        {
            _cartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = (from cl in _cartLines
                               where cl.Product.Id == product.Id
                               select cl).FirstOrDefault();
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(cl => cl.Product.Id == product.Id);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
        public int Total()
        {
            int sum = 0;
            foreach(var item in _cartLines)
            {
                sum += item.Quantity;
            }
            
            return sum;
        }
        public double GetPriceTotal()
        {
            double priceSum = 0;
            foreach(var item in _cartLines)
            {
                if(item.Quantity>1)
                {
                    priceSum += (item.Product.Price * item.Quantity);
                }
                else
                {
                    priceSum += item.Product.Price;
                }

                

            }


            return priceSum;
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}