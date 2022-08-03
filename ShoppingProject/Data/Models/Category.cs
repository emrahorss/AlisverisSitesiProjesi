using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Kategori ismi boş geçilemez")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
