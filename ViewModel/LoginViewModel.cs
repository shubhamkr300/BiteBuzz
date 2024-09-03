using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.ViewModel
{
    public class LoginViewModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static ResponseModel LoginUser(LoginModel lmodel)
        {
            ResponseModel resp = new ResponseModel();

            try
            {

                var login = (DataContext.UserDetails.Where(u => u.UserId == lmodel.UserId && u.Password == lmodel.Password));
                if (login.Any())
                {
                    resp.Status = true;
                    resp.Message = "Login successfull!";
                    resp.UserId = lmodel.UserId;
                    return resp;
                }
                //if (ud.UserId == lmodel.UserId && ud.Password == lmodel.Password)
                //{
                //    resp.Status = true;
                //    resp.Message = "Login successfull!";

                //    return resp;
                //}
                else
                {
                    resp.Status = false;
                    resp.Message = "Incorrrect Login details";
                    return resp;
                }
            }
            catch(Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
                return resp;
            }
            
        }


        public static ResponseModel AdminLogin(AdminLoginModel admin)
        {
            ResponseModel resp = new ResponseModel();
            
            try
            {

                var login = (DataContext.Admins.Where(u => u.Userid == admin.Username && u.Password == admin.Password));
                if (login.Any())
                {
                    resp.Status = true;
                    resp.Message = "Login successfull!";
                    //resp.UserId = admin.Username;
                    return resp;
                }
                //if (ud.UserId == lmodel.UserId && ud.Password == lmodel.Password)
                //{
                //    resp.Status = true;
                //    resp.Message = "Login successfull!";

                //    return resp;
                //}
                else
                {
                    resp.Status = false;
                    resp.Message = "Incorrrect Login details";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
                return resp;
            }

        }
    }
}