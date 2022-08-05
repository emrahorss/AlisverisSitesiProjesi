using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingProject.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using System.IO;

namespace ShoppingProject.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page=1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page,8));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(UrunEkle p)
        {
            Food f = new Food();
            if (p.ImageURL != null)
            {
                //işlemler
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Image/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.Name = p.Name;
            f.Description = p.Description;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryID = p.CategoryID;

            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID=id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodID=x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.CategoryID = p.CategoryID;
            x.Description = p.Description;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
