using PagedList;
using ShopQuanAo.App_Start;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        //  [AdminAuthorize(Role = new string[] { "Manager" })]
        public ActionResult Index(int? page)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();

            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            ViewBag.Page = (page - 1) * pageSize + 1;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var ds = db.Users.OrderByDescending(m => m.UserID).ToPagedList(pageIndex, pageSize);
            return View(ds);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User model)
        {
            //if (model.CatName == null || model.CatName== "")
            //{ 
            //    ModelState.AddModelError("", "Nhập id >0");
            //    return View(model);
            //}
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    //add vao csdl
                    db.Users.Add(model);
                    // luu lai thay doi
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch (Exception ex)
            {
                TempData["error"] = "Lưu dữ liệu thất bại. Vui lòng nhập đầy đủ dữ liệu!";
                return View(model);
            }

        }

        public ActionResult Edit(int id)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            var model = db.Users.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();

            var update = db.Users.Find(model.UserID);
            update.UserName = model.UserName;
            update.Password = model.Password;
            update.Email = model.Email;
            update.Role = model.Role;
            update.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            var del = db.Users.Find(id);
            db.Users.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}