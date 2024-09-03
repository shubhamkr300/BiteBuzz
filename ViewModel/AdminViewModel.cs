using FoodDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliveryApplication.ViewModel
{
    public class AdminViewModel
    {
        static FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static ResponseModel SaveProduct(FoodModel fmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                foodDetail ct = null;

                if (fmodel.fid == 0)
                {
                    ct = new foodDetail();
                    ct.Category = fmodel.Category;
                    ct.Name = fmodel.Name;
                    ct.Price = fmodel.Price;
                    if (fmodel.ImgPath != null)
                    {
                        ct.ImgPath = LoadDataModel.SaveImage(fmodel.ImgPath);
                    }
                    DataContext.foodDetails.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "Item added successsfully";

                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.foodDetails where v.fid == fmodel.fid select v).FirstOrDefault();
                    {
                        ct.Category = fmodel.Category;
                        ct.Name = fmodel.Name;
                        ct.Price = fmodel.Price;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "Food Details Updated Successfully...";
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

        public static List<FoodModel> GetAllProductLists() 
        {
            var slist = (from v in DataContext.foodDetails
                         select new FoodModel
                         {
                             fid = v.fid,
                             Category = v.Category,
                             Name = v.Name,  
                             Price= (decimal)v.Price,
                         }).ToList();
            return slist;
        }

        public static ResponseModel SaveDistrict(DistrictModel dmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                tblDistrict dt = null;

                if (dmodel.dId == 0)
                {
                    dt = new tblDistrict();
                    dt.state = dmodel.state;
                    dt.dName = dmodel.dName;
                    DataContext.tblDistricts.InsertOnSubmit(dt);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "District added successsfully";

                    return resp;
                }
                else
                {
                    dt = (from v in DataContext.tblDistricts where v.d_Id == dmodel.dId select v).FirstOrDefault();
                    {
                        dt.state = dmodel.state;
                        dt.dName = dmodel.dName;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "District Details Updated Successfully...";
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
        public static List<DistrictModel> GetAllDistrictLists()
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");

            var dlist = ( from v in DataContext.tblDistricts
                          select new  DistrictModel
                          {
                              dId = v.d_Id,
                              state = v.state,
                              dName = v.dName,
                          }).ToList();
            return dlist;
        }

        public static DistrictModel EditDistrictLists(int id)
        {
            DistrictModel smodel = new DistrictModel();
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            var sdata = (from s in DataContext.tblDistricts where s.d_Id == id select s);
            if (sdata.Any())
            {
                var r = sdata.First();
                smodel.dId = r.d_Id;    
                smodel.state = r.state;
                smodel.dName = r.dName;
            }
            return smodel;

        }


        public static ResponseModel DeleteDistrictLists(int id)
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            ResponseModel resp = new ResponseModel();
            var mcheck = (from r in DataContext.tblDistricts where r.d_Id == id select r);
            if(mcheck.Any())
            {
                DataContext.tblDistricts.DeleteOnSubmit(mcheck.First());
                DataContext.SubmitChanges();
                resp.Status = true;
                resp.Message = "Data Delete Sucessfully...";
                return resp;
            }
            else
            {
                resp.Status = false;
                resp.Message = "Data delete Faielde...";
                return resp;
            }

        
        }


        public static ResponseModel SaveCity(CityModel cmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                tblCity ct = null;

                //var Dname = (from v in DataContext.tblDistricts
                //             where v.d_Id == cmodel.dId
                //             select v.dName);


                if (cmodel.cId == 0)
                {
                    ct = new tblCity();
                    ct.dName = cmodel.dName;
                    ct.cName = cmodel.cName;
                    DataContext.tblCities.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "City added successsfully";

                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.tblCities where v.c_Id == cmodel.cId select v).FirstOrDefault();
                    {
                        ct.dName = cmodel.dName;
                        ct.cName = cmodel.cName;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "City Details Updated Successfully...";
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

        public static List<CityModel> GetAllCityLists()
        {
            var clist = (from v in DataContext.tblCities
                         select new CityModel
                         {
                             cId = v.c_Id,
                             dName = v.dName,
                             cName = v.cName,

                         }).ToList();
            return clist;
        }

        public static CityModel EditCityLists(int id)
        {
            CityModel smodel = new CityModel();
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            var sdata = (from s in DataContext.tblCities where s.c_Id == id select s);
            if (sdata.Any())
            {
                var r = sdata.First();
                smodel.cId = r.c_Id;
                smodel.dName = r.dName;
                smodel.cName = r.cName;
            }
            return smodel;

        }


        public static ResponseModel DeleteCityLists(int id)
        {
            FoodDataDataContext DataContext = new FoodDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=FoodDb;User ID=sa;Password=9431353474;Encrypt=False");
            ResponseModel resp = new ResponseModel();
            var mcheck = (from s in DataContext.tblCities where s.c_Id == id select s);
            if (mcheck.Any())
            {
                DataContext.tblCities.DeleteOnSubmit(mcheck.First());
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

        public static List<UserModel> GetAllUserLists()
        {
            var ulist = (from v in DataContext.UserDetails
                         select new UserModel
                         {
                             UserId = v.UserId,
                             Name = v.Name,
                             Gender = v.Gender,
                             Email = v.Email,
                             Phone = v.Phone,
                             Password = v.Password,
                         }).ToList();
            return ulist;      
        }

        public static List<OrderDetailsModel> getOrderList()
        {
            var orderList = (from order in DataContext.tblOrders
                             join prod in DataContext.foodDetails on order.fid equals prod.fid
                             select new OrderDetailsModel
                             {
                                 orderId = order.Oid,
                                 userId = (int)order.User_Id,
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