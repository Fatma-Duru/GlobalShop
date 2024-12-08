using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlobalShop.Entity;

namespace GlobalShop.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public List<CartLine> CartLine
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _cartLines.Add(new Models.CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += 1;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return _cartLines.Sum(i=>i.Product.Price*i.Quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}