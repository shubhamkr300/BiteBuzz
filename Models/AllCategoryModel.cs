using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliveryApplication.Models
{
    public class AllCategoryModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public List<SelectListItem> AllDistrictList()
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            List<SelectListItem> nList = new List<SelectListItem>();
            
            var blist = (from v in DataContext.tblDistricts
                         orderby v.dName ascending
                         select v).ToList();
            foreach( var b in blist )
            {
                SelectListItem slist = new SelectListItem();
                slist.Value = b.dName;
                slist.Text = b.dName;
                nList.Add(slist);
            }
            return nList;
        }
    }
}