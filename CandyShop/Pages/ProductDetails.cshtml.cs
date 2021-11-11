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
    public class ProductInformationModel : PageModel
    {
        public List<ProductModel> ProductDetailsView { get; set; } = new List<ProductModel>();

        public void OnGet(int id)
        {
            List<Models.ProductModel> products = ProductManager.GetProducts();

            var detailsResult = products.Where(product => product.Id == id).ToList();
            ProductDetailsView = detailsResult;
        }
    }
}
