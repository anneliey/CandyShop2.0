using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandyShop.Pages
{
    public class ChipsProductsModel : PageModel
    {
        public List<ProductModel> ChipsProductView { get; set; } = new List<ProductModel>();
        public void OnGet()
        {
            List<ProductModel> products = ProductManager.GetProducts();

            var result = products.Where(product => product.Category.Contains("Chips")).ToList();
            ChipsProductView = result;
        }
    }
}