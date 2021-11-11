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
    public class CartModel : PageModel
    {
        // public static List<CartModel> CartView { get; set; } = new List<CartModel>();
        public List<ProductModel> CartView { get; set; } = new List<ProductModel>();
        public List<ShippingModel> ShippingView { get; set; } = new List<ShippingModel>();

        public void OnGet(int id)
        {
            List<Models.ProductModel> products = ProductManager.GetProducts();

            var cartResult = products.Where(product => product.Id == id).ToList();
            CartView = cartResult;

            List<Models.ShippingModel> shippingMethods = ShippingManager.GetShippingMethods();
            var shippingResult = shippingMethods.ToList();
            ShippingView = shippingResult;

        }

        public static void OnPost()
        {
             //string TotalPrice =
        }
    }
}
