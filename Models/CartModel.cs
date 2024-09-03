using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class CartModel
    {
        public int cartId { get; set; }

        public int fid { get; set; }
        public String productName { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public decimal amount { get; set; }
        public decimal total { get; set; }

    }
}