using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using FoodDeliveryApplication.Models;
using FoodDeliveryApplication.ViewModel;
using System.Web.Hosting;

namespace FoodDeliveryApplication.Controllers
{
    public class WebController : Controller
    {
       
        // GET: Web
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu() 
        {
            List<FoodModel> flist = MenuViewModel.getFoodList();
            if (flist != null)
            {
                return View(flist);

            }
            else
            {
                ViewData["Message"] = "Item not present";
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Menu(int fid,int user_id)
        //{
        //    FoodModel fm = new FoodModel();
        //    fm.fid = fid;
        //    fm.user_id = user_id;
        //    fm.quantity = 1;

        //    ResponseModel resp = ViewModel.CartViewModel.AddToCart(fm);
        //    if (resp.Status == true)
        //    {
        //        ViewData["Message"] = "Item added successfully!";
        //    }
        //    else
        //    {
        //        ViewData["Message"] = "Item not added";
        //    }
        //    return RedirectToAction("Menu");
        //}


        [HttpPost]
        public JsonResult Menu(int fid,int quantity)
        {
            var foodModel = new FoodModel
            {
                fid = fid,
                quantity = quantity,
                user_id = (int)Session["userId"]
            };

            ResponseModel resp = ViewModel.CartViewModel.AddToCart(foodModel);
            if (resp.Status)
            {
                return Json(new { result = "Item added successfully!" });
            }
            else
            {
                return Json(new { result = "Item not added" });
            }
        }


        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public JsonResult GetCartList()
        {
            int user_id = (int)Session["userId"];
            List<CartModel> clist = CartViewModel.getCartDetails(user_id);
            return Json(new { data = clist }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletefromCart(int id)
        {
            if (id > 0)
            {
                ResponseModel resp = CartViewModel.DeletefromCart(id);
                if (resp.Status == true)
                {
                    return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "Delete from cart failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SavetoOrders()
        {
            int sid = (int)Session["userId"];
            ResponseModel resp = OrderViewModel.SaveToOrders(sid);
            if (resp.Status == true)
            {
                return RedirectToAction("Cart");
                //return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Orders()
        {
            return View();
        }

        public JsonResult GetOrderList()
        {
            int sid = (int)Session["userId"];
            List<CartModel> olist = OrderViewModel.getOrderList(sid);
            return Json(new { data = olist }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Cart(int fid)
        //{
        //    int user_id = (int)Session["userId"];
        //    List<Cart> clist = ViewModel.CartViewModel.getCartDetails(user_id);
        //    if (clist != null)
        //    {
        //        return View(clist);

        //    }
        //    else
        //    {
        //        ViewData["Message"] = "Item not present";
        //    }
        //    return View();
        //}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginModel lmodel)
        {
            ResponseModel resp = LoginViewModel.LoginUser(lmodel);
            if (resp.Status == true)
            {

                Session["userId"] = resp.UserId;
                ViewBag.Message = resp.UserId;
                //  return Json(new { result = true, message = resp.Message }, JsonRequestBehavior.AllowGet);

                return RedirectToAction("Index");
            }
            else
            { 
                return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Register(UserModel cmodel)
        {
            ResponseModel resp = AddUserViewModel.SaveUser(cmodel);
            if (resp.Status == true)
            {
                ViewBag.Message = "Data Saved";
                return RedirectToAction("Login");
            }
            else
                return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Register(User ur)
        //{
        //    try
        //    {
        //        if (dal.InsertData(ur))
        //        {
        //            ViewBag.Message = "Data Saved";
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return View();
        //    }
        //}
      
    }
}