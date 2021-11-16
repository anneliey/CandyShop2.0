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
        public static List<ProductModel> CartProducts { get; set; } = GetProducts();
        public List<ProductModel> CartView { get; set; } = new List<ProductModel>();
        public List<ShippingModel> ShippingView { get; set; } = new List<ShippingModel>();
        public static double totalSum;
        public static int quantity;

        

        // Ändra sen
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ShippingOption { get; set; }
        public string PaymentOption { get; set; }

        public static List<ProductModel> GetProducts()
        {
            if (CartProducts == null || !CartProducts.Any())
            {
                CartProducts = new List<ProductModel>();
            }

            return CartProducts;
        }

        public void OnGet(int id, int removeId, int addId)
        {

            AddToCart(id);
            UpdateQuantity(removeId, addId);

            CartView = CartProducts;
            totalSum = CartProducts.Sum(product => product.Price);

            List<ShippingModel> shippingMethods = ShippingManager.GetShippingMethods();
            var shippingResult = shippingMethods.ToList();
            ShippingView = shippingResult;

        }

        public static List<ProductModel> AddToCart(int id)
        {
            List<ProductModel> products = ProductManager.GetProducts();
            var cartResult = products.Where(product => product.Id == id).FirstOrDefault();

            if (id != 0) {
                CartProducts.Add(cartResult);
            }
            return CartProducts;
        }

        public static List<ProductModel> RemoveFromCart(int removeId)
        {
            List<ProductModel> products = ProductManager.GetProducts();
            var cartResult = products.Where(product => product.Id == removeId).FirstOrDefault();

        
            CartProducts.Remove(cartResult);
       
            return CartProducts;
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
        public static void UpdateQuantity(int removeId, int addId)
        {
            if (addId != 0)
            {
                CartProducts = AddToCart(addId);             
            }
            if (removeId != 0)
            {
                CartProducts = RemoveFromCart(removeId);
            }
        }

    }
}
    

