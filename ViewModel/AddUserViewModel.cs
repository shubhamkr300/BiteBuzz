using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.ViewModel
{
    public class AddUserViewModel
    {
        //public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FoodDbConnectionString"].ConnectionString);

        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");



        public static ResponseModel SaveUser(UserModel cmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
               UserDetail ct = null;

                if (cmodel.UserId == 0)
                {
                    ct = new UserDetail();
                    ct.Name = cmodel.Name;
                    ct.Email = cmodel.Email;
                    ct.Phone = cmodel.Phone;
                    ct.Password = cmodel.Password;
                    ct.Gender = cmodel.Gender;
                    DataContext.UserDetails.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "User Registered successsfully";
                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.UserDetails where v.UserId == cmodel.UserId select v).FirstOrDefault();
                    {
                        ct.Name = cmodel.Name;
                        ct.Email = cmodel.Email;
                        ct.Phone = cmodel.Phone;
                        ct.Password = cmodel.Password;
                        ct.Gender = cmodel.Gender;
                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "User Details Updated Successfully...";
                        return resp;
                    }
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