﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly CandyShop.Data.ProductContext _context;

        public DeleteModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.DbProducts.FirstOrDefaultAsync(m => m.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.DbProducts.FindAsync(id);

            if (ProductModel != null)
            {
                _context.DbProducts.Remove(ProductModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}