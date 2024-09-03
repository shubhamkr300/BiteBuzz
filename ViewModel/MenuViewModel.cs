using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.ViewModel
{
    public class MenuViewModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static List<FoodModel> getFoodList()
        {
            ResponseModel resp = new ResponseModel();

            List<FoodModel> foodList = new List<FoodModel>();
            var foods = DataContext.foodDetails.ToList();
            try
            {
                if (foods != null)
                {

                    foreach (var food in foods)
                    {
                        var FoodModel = new FoodModel()
                        {
                            fid = food.fid,
                            Category = food.Category,
                            Name = food.Name,
                            Price = (decimal)food.Price,
                            getImage = ("~/user_images/") + Path.GetFileName(food.ImgPath)
                        };
                        foodList.Add(FoodModel);
                    }
                    resp.Status = true;
                    resp.Message = "Food Details Updated Successfully...";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }
            return foodList;
        }
    }
}