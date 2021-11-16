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
    public class CandyProductsModel : PageModel
    {
        public IEnumerable<ProductModel> CandyProductView { get; set; } = new List<ProductModel>();
        public IEnumerable<ProductModel> CandyDbProductView { get; set; } = new List<ProductModel>();

        [BindProperty]
        public string SearchTerm { get; set; }
        private readonly CandyShop.Data.ProductContext _context;

        public CandyProductsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            List<ProductModel> products = ProductManager.GetProducts();
            DbSet<ProductModel> dbProducts = _context.Products;
           
            var result = products.Where(product => product.Category.Contains("Candy")).ToList();
            CandyProductView = result;


            var dbResult = dbProducts.Where(product => product.Category.Contains("Candy")).ToList();
            CandyDbProductView = dbResult;
        }
        public void OnPost()
        {
            CandyProductView = new ProductManager(_context).Search(SearchTerm);
        }

    }
}
