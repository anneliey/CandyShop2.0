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
    [BindProperties]
    public class CartModel : PageModel
    {
        // public static List<CartModel> CartView { get; set; } = new List<CartModel>();
        public List<ProductModel> CartView { get; set; } = new List<ProductModel>();
        public List<ShippingModel> ShippingView { get; set; } = new List<ShippingModel>();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ShippingOption { get; set; }
        public string PaymentOption { get; set; }

        public void OnGet(int id)
        {
            List<Models.ProductModel> products = ProductManager.GetProducts();

            var cartResult = products.Where(product => product.Id == id).ToList();
            CartView = cartResult;

            List<Models.ShippingModel> shippingMethods = ShippingManager.GetShippingMethods();
            var shippingResult = shippingMethods.ToList();
            ShippingView = shippingResult;

        }

        public IActionResult OnPost()
        {
            if (ShippingOption == "DHL")
            {
                //CartManager.TotalAmount += 99;
            }
            else
            {
                //CartManager.TotalAmount += 39;
            }
            if (PaymentOption == "Klarna (29 SEK)")
            {
                //CartManager.TotalAmount += 29;
            }
            return RedirectToPage("/Confirmation", new { Name, Email, Number, Adress, City, PostalCode, ShippingOption, PaymentOption });
        }
    }
}
    

