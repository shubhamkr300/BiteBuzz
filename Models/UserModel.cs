using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class UserModel
    {
 
        public int UserId { get; set; }

        [Required(ErrorMessage ="Please Enter Your name")]
        public string Name { get; set; }

        [Required ]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}