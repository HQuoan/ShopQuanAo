using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        // GET: Admin/ProductImage
        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}