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
    public class ProductDetailsModel : PageModel
    {
        public List<ProductModel> ProductDetailsView { get; set; } = new List<ProductModel>();
        public List<ProductModel> DbProductDetailsView { get; set; } = new List<ProductModel>();
        private readonly CandyShop.Data.ProductContext _context;

        public ProductDetailsModel(CandyShop.Data.ProductContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            List<ProductModel> products = ProductManager.GetProducts();
            DbSet<ProductModel> dbProducts = _context.Products;

            var detailsResult = products.Where(product => product.Id == id).ToList();
            ProductDetailsView = detailsResult;

            var dbResult = dbProducts.Where(product => product.Id == id).ToList();
            DbProductDetailsView = dbResult;
        }
    }
}
