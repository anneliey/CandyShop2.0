using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Pages
{
    public class IndexModel : PageModel
    {
        
        public List<ProductModel> IndexProductView { get; set; } = new List<ProductModel>();
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            List<ProductModel> products = ProductManager.GetProducts();
            // Randomizes 3 products to index page
            int nrOfProducts = 3;
            var random = new Random();
            var result = products.OrderBy(product => random.Next()).Take(nrOfProducts).ToList();
            IndexProductView = result;
        }
    }
}
