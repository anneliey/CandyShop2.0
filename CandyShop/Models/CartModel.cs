using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    // NOTE: "CartItem"
    public class CartModel
    {
        [Key]
        public string ItemId { get; set; }

        public int Quantity { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
