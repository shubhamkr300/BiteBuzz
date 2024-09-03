using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FoodDeliveryApplication.ViewModel
{
    public class CartViewModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static ResponseModel AddToCart(FoodModel fmodel)
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

            ResponseModel resp = new ResponseModel();

            cartDetail ct = null;

            try
            {
                //var foods = DataContext.foodDetails.Where(x => x.fid == id).SingleOrDefault();

                ct = new cartDetail();
                ct.User_Id = fmodel.user_id;
                ct.Product_Id = fmodel.fid;
                ct.Quantity = fmodel.quantity;

                DataContext.cartDetails.InsertOnSubmit(ct);
                DataContext.SubmitChanges();
                resp.Status = true;
                resp.Message = "User Registered successsfully";


            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;

            }
            return resp;
        }

        public static List<CartModel> getCartDetails(int sid)
        {
            var cartList = (from cart in DataContext.cartDetails
                         join prod in DataContext.foodDetails on cart.Product_Id equals prod.fid
                         where cart.User_Id == sid
                         select new CartModel
                         {
                             cartId = cart.Cart_Id,
                             fid = prod.fid,
                             productName = prod.Name,
                             price = (decimal)prod.Price,
                             quantity = cart.Quantity,
                             amount = (decimal)(prod.Price * cart.Quantity)
                         }).ToList();
            return cartList;
        }

        public static ResponseModel DeletefromCart(int id)
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            ResponseModel resp = new ResponseModel();
            var mcheck = (from r in DataContext.cartDetails where r.Cart_Id == id select r);
            if (mcheck.Any())
            {
                DataContext.cartDetails.DeleteOnSubmit(mcheck.First());
                DataContext.SubmitChanges();
                resp.Status = true;
                resp.Message = "Data Delete Sucessfully...";
                return resp;
            }
            else
            {
                resp.Status = false;
                resp.Message = "Data delete Failed...";
                return resp;
            }


        }
    }
}