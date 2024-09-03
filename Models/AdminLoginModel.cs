using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class AdminLoginModel
    {
        [Required(ErrorMessage = "Please Enter UserId")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]

        public string Password { get; set; }
    }
}