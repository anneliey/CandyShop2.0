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
    public class AllProductsModel : PageModel
    {
        
        public IEnumerable<ProductModel> ProductView { get; set; } = new List<ProductModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public void OnGet()
        {
            ProductView = ProductManager.Search(SearchTerm);
            //List<Models.ProductModel> products = ProductManager.GetProducts();

            //var result = products.OrderBy(product => product.Name).ToList();
            //ProductView = result;
        }
        
    }
}
