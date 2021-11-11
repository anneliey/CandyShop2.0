using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Data
{
    public class CartManager
    {
        public static List<CartModel> Cart { get; set; } = new List<CartModel>();

            public static List<CartModel> GetCart()
            {
                return Cart;
            }
        }
}
