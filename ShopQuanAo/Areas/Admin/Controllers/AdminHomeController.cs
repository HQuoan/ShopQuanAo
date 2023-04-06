using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopQuanAo.App_Start;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome

      // [AdminAuthorize(Role = new string[] { "Admin", "Manager" })]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            var account = db.Users.SingleOrDefault(m => m.UserName == user && m.Password == password);

            if (account != null)
            {
                // tao session
                Session["user"] = account;
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Tai khoan dang nhap khong dung";
                return View();
            }
        }

        public ActionResult Logout()
        {
            //xoa session
            Session.Remove("user");
            // xoa cookies form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();

            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Role = 2; 
                //add vao csdl
                db.Users.Add(model);
                // luu lai thay doi
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            TempData["error"] = "Vui lòng nhập đầy đủ thông tin";
            return View(model);
        }
        public ActionResult ChuyenVeUserHome()
        {
            return Redirect("~/Home");
        }
        public ActionResult BaoLoi()
        {
            return View();
        }
    }
}