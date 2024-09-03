using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.ViewModel
{
    public class OrderViewModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static ResponseModel SaveToOrders(int sid)
        {
            ResponseModel resp = new ResponseModel();
            List<OrderModel> olist = new List<OrderModel>();
            tblOrder tbo = null;
            try
            {
                var foods = DataContext.cartDetails.Where(x => x.User_Id == sid).ToList();

                foreach (var food in foods)
                {
                    tbo = new tblOrder();
                    tbo.User_Id = food.User_Id;
                    tbo.fid = food.Product_Id;
                    tbo.Quantity = food.Quantity;

                    DataContext.tblOrders.InsertOnSubmit(tbo);
                    DataContext.SubmitChanges();

                    DataContext.cartDetails.DeleteOnSubmit(food);
                    DataContext.SubmitChanges();
                }
                resp.Status = true;
                resp.Message = "Your Orders have been placed successsfully";
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;

            }
            return resp;
        }

        public static List<CartModel> getOrderList(int sid)
        {
            var orderList = (from order in DataContext.tblOrders
                            join prod in DataContext.foodDetails on order.fid equals prod.fid
                            where order.User_Id == sid
                            select new CartModel
                            {
                                cartId = order.Oid,
                                fid = prod.fid,
                                productName = prod.Name,
                                price = (decimal)prod.Price,
                                quantity = order.Quantity,
                                amount = (decimal)(prod.Price * order.Quantity)
                            }).ToList();
            return orderList;
        }
    }
}