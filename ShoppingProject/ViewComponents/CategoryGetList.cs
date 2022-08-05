using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Repositories;

namespace ShoppingProject.ViewComponents
{
    public class CategoryGetList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categorylist = categoryRepository.TList();
            return View(categorylist);
        }
    }
}
