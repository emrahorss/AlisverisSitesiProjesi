using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingProject.Data.Models;

namespace ShoppingProject.ViewComponents
{
    public class FoodListByCategory: ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.List(x => x.CategoryID == id);
            return View(foodlist);
        }
    }
}
