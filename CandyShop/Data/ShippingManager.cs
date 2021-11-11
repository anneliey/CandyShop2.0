using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Data
{
    public class ShippingManager
    {
        public static List<ShippingModel> ShippingMethods { get; set; } = new List<ShippingModel>();

        public static List<ShippingModel> GetShippingMethods()
        {
            if (!ShippingMethods.Any())
            {
                ShippingMethods = new List<ShippingModel>()
                {
                    new ShippingModel()
                    {
                        ShippingName = "Express leverans 1-2 arbetsdagar",
                        ShippingId = "Express",
                        ShippingPrice = 89
                    },
                    new ShippingModel()
                    {
                        ShippingName = "Postnord leverans 3-5 arbetsdagar",
                        ShippingId = "Postnord",
                        ShippingPrice = 59
                    },

                };

            }
            return ShippingMethods;
        }
    }
}
