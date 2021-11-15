using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;

namespace CandyShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly CandyShop.Data.ProductContext _context;

        public DetailsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }

        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
