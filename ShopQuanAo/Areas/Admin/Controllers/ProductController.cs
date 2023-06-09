﻿using PagedList;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private ShopQuanAoEntities db = new ShopQuanAoEntities();
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            ViewBag.Page = (page - 1) * pageSize + 1;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var ds = db.Products.OrderByDescending(m => m.ProductID).ToPagedList(pageIndex, pageSize);
            return View(ds);
        }
        public ActionResult Add()
        {         
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (Images != null && Images.Count > 0)
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    if (i + 1 == rDefault[0])
                    {
                        model.ListImages = Images[i];
                        model.ProductImages.Add(new ProductImage
                        {
                            ProductID = model.ProductID,
                            Image = Images[i],
                            isDefault = true
                        });
                    }
                    else
                    {
                        model.ProductImages.Add(new ProductImage
                        {
                            ProductID = model.ProductID,
                            Image = Images[i],
                            isDefault = false
                        });
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng thêm hình ảnh đại diện!");
                return View(model);
            }


            try
            {
                if (ModelState.IsValid)
                {

                    //add vao csdl
                    model.CreateDate = DateTime.Now;
                    db.Products.Add(model);
                    // luu lai thay doi
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Lưu dữ liệu thất bại. Vui lòng thử lại!";
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "CatID", "CatName");
            var model = db.Products.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            var update = db.Products.Find(model.ProductID);
            update.ProductName = model.ProductName;
            update.Title = model.Title;
            update.Description = model.Description;
            update.CatID = model.CatID;
            update.Quantity = model.Quantity;
            update.Price = model.Price;
            update.PromotionPrice = model.PromotionPrice;
            update.Status = model.Status;
            update.isHot = model.isHot;
            update.isSale = model.isSale;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var del = db.Products.Find(id);
            db.Products.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}