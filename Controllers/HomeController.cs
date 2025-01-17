﻿using GlobalShop.Entity;
using GlobalShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        DataContext _conetext = new DataContext();

        public ActionResult Index()
        {
            var urunler = _conetext.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id= i.Id,   
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId,  

                }).ToList();
            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            return View(_conetext.Products.Where(i => i.Id == id).FirstOrDefault());
        }

        public ActionResult List(int ? id )
        {
            var urunler = _conetext.Products
                 .Where(i => i.IsApproved)
                 .Select(i => new ProductModel()
                 {
                     Id = i.Id,
                     Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                     Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                     Price = i.Price,
                     Stock = i.Stock,
                     Image = i.Image ?? "Kulaklik.jpg",
                     CategoryId = i.CategoryId,

                 }).AsQueryable();
            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_conetext.Categories.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

    }
}