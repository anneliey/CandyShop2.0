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
    public class SodaProductsModel : PageModel
    {
        public IEnumerable<ProductModel> SodaProductView { get; set; } = new List<ProductModel>();

        [BindProperty]
        public string SearchTerm { get; set; }

        private readonly CandyShop.Data.ProductContext _context;

        public SodaProductsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            List<ProductModel> products = ProductManager.GetProducts();

            var result = products.Where(product => product.Category.Contains("Soda")).ToList();
            SodaProductView = result;
        }
        public void OnPost()
        {
            SodaProductView = new ProductManager(_context).Search(SearchTerm);
        }
    }
}
