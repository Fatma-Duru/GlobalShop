﻿using GlobalShop.Entity;
using GlobalShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart


        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);

            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);

            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;

        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());

        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLine.Count == 0)
            {

                ModelState.AddModelError("UrunYokError", "Sepetinizde Bir Ürün Bulunmamaktadır");
            }
            if (ModelState.IsValid)
            {
                //Siparişi Veri Tabanına Kaydet 
                //cart'ı Sıfırla 
                SaveOrder(cart, entity);
                cart.Clear();

                return View("Completed");
            }
            else
            {
                return View(entity);

            }


        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random().Next(11111, 99999).ToString());
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = User.Identity.Name; 

            
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();

            foreach (var pr in cart.CartLine)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;
                order.OrderLines.Add(orderline);

            }
            db.Orders.Add(order);
            db.SaveChanges();
            


        }
    }
}