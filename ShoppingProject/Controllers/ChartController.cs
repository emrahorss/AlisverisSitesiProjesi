using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Data;
using System;
using System.Collections.Generic;
using ShoppingProject.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Pie()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs1 = new List<Class1>();
            using (var d = new Context())
            {
                cs1 = d.Foods.Select(x => new Class1
                {
                    proname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs1;
        }
        public IActionResult Column()
        {
            return View();
        }
        public IActionResult Dynamic()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();

            //Toplam Ürün Sayısı
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            //Toplam Kategori Sayısı
            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            //Temel Gıda Sayısı
            var deger3 = c.Foods.Where(x => x.CategoryID==5).Count();
            ViewBag.d3 = deger3;

            //İçecek Sayısı
            var deger4 = c.Foods.Where(x => x.CategoryID == 9).Count();
            ViewBag.d4 = deger4;

            //Max Ürün Stok Sayısı
            var deger5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;

            //Kahvaltılık Sayısı
            var deger6 = c.Foods.Where(x => x.CategoryID == 4).Count();
            ViewBag.d6 = deger6;

            //Max Yiyecek Stok
            var deger7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            //Min Yiyecek Stok
            var deger8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;

            //Max Tahıl Sayısı
            var deger9 = c.Categories.OrderByDescending(x => x.CategoryID == 10).Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d9 = deger9;

            //Min Tahıl Sayısı
            var deger10 = c.Categories.OrderBy(x => x.CategoryID == 10).Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d10 = deger10;

            //Max İçecek Sayısı
            var deger11 = c.Categories.OrderByDescending(x => x.CategoryID == 9).Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d11 = deger11;

            //Min Yiyecek Stok
            var deger12 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d12 = deger12;

            return View();
        }
    }
}
