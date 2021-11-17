using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Pages
{
    public class ChipsProductsModel : PageModel
    {
        public IEnumerable<ProductModel> ChipsProductView { get; set; } = new List<ProductModel>();
        public IEnumerable<ProductModel> ChipsDbProductView { get; set; } = new List<ProductModel>();


        [BindProperty]
        public string SearchTerm { get; set; }

        private readonly CandyShop.Data.ProductContext _context;

        public ChipsProductsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            List<ProductModel> products = ProductManager.GetProducts();
            DbSet<ProductModel> dbProducts = _context.Products;

            var result = products.Where(product => product.Category.Contains("Chips")).ToList();
            ChipsProductView = result;

            var dbResult = dbProducts.Where(product => product.Category.Contains("Chips")).ToList();
            ChipsDbProductView = dbResult;
        }
        public void OnPost()
        {
            ChipsProductView = new ProductManager(_context).Search(SearchTerm);
        }
    }
}
