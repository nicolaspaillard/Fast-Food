using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Models
{
    public class ProductsViewModel
    {
        public Menu Menu { get; set; }
        public List<SelectListItem> Burgers { get; set; } = new();
        public List<SelectListItem> Beverages { get; set; } = new();
        public List<SelectListItem> Desserts { get; set; } = new();
        public List<SelectListItem> Sides { get; set; } = new();
    }
}
