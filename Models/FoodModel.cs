using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class FoodModel
    {

        public int fid { get; set; }

        [Required(ErrorMessage ="Please select category!")]
        [Display(Name ="Select Category:")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Enter Item name!")]
        [Display(Name = "Item Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please upload file!")]
        [Display(Name = "Upload Image:")]
        public HttpPostedFileBase ImgPath { get; set; }

        public string getImage { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [Display(Name = "Price:")]
        public decimal Price { get; set; }

        public int user_id { get; set; }

        public int quantity { get; set; }

    }
}