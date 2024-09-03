using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class OrderDetailsModel
    {
        public int orderId { get; set; }

        public int userId { get; set; }

        public int fid { get; set; }
        public String productName { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public decimal amount { get; set; }
        public decimal total { get; set; }
    }
}