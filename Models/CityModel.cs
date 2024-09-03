using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FoodDeliveryApplication.Models
{
    public class CityModel
    {
        public int cId { get; set; }

        public int dId { get; set; }

        public List<SelectListItem> districtList { get; set; }
        public string dName { get; set; }
        public string cName { get; set; }
    }
}