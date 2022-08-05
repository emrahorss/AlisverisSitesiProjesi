using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.ViewComponents
{
    public class FoodGetList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.TList();
            return View(foodlist);
        }
    }
}
