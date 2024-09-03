using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class OrderModel
    {
        public int Oid { get; set; }

        public int UserId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }
    }
}