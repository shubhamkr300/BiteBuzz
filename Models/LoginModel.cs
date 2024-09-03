using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Please Enter Your Password")]

        public string Password { get; set; }    


    }
}