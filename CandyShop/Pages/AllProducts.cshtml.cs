using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;

namespace CandyShop.Pages
{
    public class AllProductsModel : PageModel
    {
        public IEnumerable<ProductModel> ProductView { get; set; } = new List<ProductModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        private readonly ProductContext _context;

        public AllProductsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<ProductModel> ProductModel { get; set; }

        public async Task OnGetAsync()
        {
            ProductView = new ProductManager(_context).Search(SearchTerm);
            //ProductModel = await _context.Products.ToListAsync();
        }
    }
}
