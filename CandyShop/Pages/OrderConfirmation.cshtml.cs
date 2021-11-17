using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandyShop.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ShippingOption { get; set; }
        public string PaymentOption { get; set; }
        public double totalSum { get; set; }
        public List<Models.ProductModel> CartProducts { get; private set; }

<<<<<<< Updated upstream
        public void OnGet(string name, string email, string number, string adress, string city, string postalcode, 
            string shippingOption, string paymentOption)
=======
        public void OnGet(string name, string email, string number, string adress, string city, 
            string postalcode, string shippingOption, string paymentOption)
>>>>>>> Stashed changes
        {
            Name = name;
            Email = email;
            Number = number;
            Adress = adress;
            City = city;
            PostalCode = postalcode;
            ShippingOption = shippingOption;
            PaymentOption = paymentOption;

            totalSum = CartModel.totalSum;
            CartProducts = CartModel.CartProducts;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        }
    }
}
