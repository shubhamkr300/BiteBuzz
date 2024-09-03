using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using FoodDeliveryApplication.Models;
using FoodDeliveryApplication.ViewModel;
using System.Collections;
using System.Security.Cryptography;

namespace FoodDeliveryApplication.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLogin()
        {
            return View();
        }
        // GET: Admin
        [HttpPost]
        public ActionResult AdminLogin(AdminLoginModel al)
        {
            ResponseModel resp = LoginViewModel.AdminLogin(al);
            if (resp.Status == true)
            {
                Session["userId"] = resp.UserId;
                ViewBag.Message = resp.UserId;
                //Session["UserId"] = resp.UserId;
                //  return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);

                return RedirectToAction("Index");
            }
            else
            {
                return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult District()
        {
            return View();
        }

        [HttpPost]
        public ActionResult District(DistrictModel dt)
        {
            ResponseModel resp = AdminViewModel.SaveDistrict(dt);
            if (resp.Status == true)
            {
                ViewData["Message"] = "District added successfully!";
            }
            else
            {
                ViewData["Message"] = "District not added";
            }
            return View();
        }

        public JsonResult GetDistrictLists()
        {
            List<DistrictModel> dlist = AdminViewModel.GetAllDistrictLists();
            return Json(new { data = dlist }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditDistrict(int id)
        {
            if(id>0)
            {
                DistrictModel smodel = AdminViewModel.EditDistrictLists(id);
                return Json(smodel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "Edit District Faield.." }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteDistrict(int id)
        {
            if (id > 0)
            {
                ResponseModel resp = AdminViewModel.DeleteDistrictLists(id);
                if (resp.Status == true)
                    return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "Edit District Faield.." }, JsonRequestBehavior.AllowGet);
            }
        }




        public ActionResult City()
        {
            AllCategoryModel cl = new AllCategoryModel();
            CityModel ct = new CityModel();
            ct.districtList = cl.AllDistrictList();
            return View(ct);
        }

        [HttpPost]
        public ActionResult City(CityModel ct)
        {
            ResponseModel resp = ViewModel.AdminViewModel.SaveCity(ct);
            if (resp.Status == true)
            {
                ViewData["Message"] = "City added successfully!";
            }
            else
            {
                ViewData["Message"] = "City not added";
            }
            return RedirectToAction("City");
        }

     
        public JsonResult GetCityLists()
        {
            List<CityModel> clist = AdminViewModel.GetAllCityLists();
            return Json(new { data = clist }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditCity(int id)
        {
            if (id > 0)
            {
                CityModel smodel = AdminViewModel.EditCityLists(id);
                return Json(smodel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "Edit City Failed.." }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteCity(int id)
        {
            if (id > 0)
            {
                ResponseModel resp = AdminViewModel.DeleteCityLists(id);
                if (resp.Status == true)
                    return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "Edit District Failed.." }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Product(FoodModel fm)
        {
            ResponseModel resp = ViewModel.AdminViewModel.SaveProduct(fm);
            if (resp.Status == true)
            {
                ViewData["Message"] = "Item added successfully!";
            }
            else
            {
                ViewData["Message"] = "Item not added";
            }
            return View();
        }

        public JsonResult GetProductLists()
        { 
           List<FoodModel> cmlist = AdminViewModel.GetAllProductLists();
            return Json(new {data = cmlist},JsonRequestBehavior.AllowGet);
        }



        public ActionResult User_Details()
        {
            return View();
        }

        public JsonResult GetUserDetails()
        {
            List<UserModel> ulist = AdminViewModel.GetAllUserLists();
            return Json(new { data = ulist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Orders()
        {
            return View();
        }

        public JsonResult GetOrderRequests()
        {
            List<OrderDetailsModel> olist = AdminViewModel.getOrderList();
            return Json(new { data = olist }, JsonRequestBehavior.AllowGet);
        }
    }
}