using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopQuanAo.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public string[] Role { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //1.Check session: đã đăng nhập -> cho thực hiện Filter
            //Ngược lại thi cho trở lại -> trang đăng nhập 
            User nvSession = (User)HttpContext.Current.Session["user"];
            ShopQuanAoEntities db = new ShopQuanAoEntities();


            if (nvSession != null)
            {

                Role role = db.Roles.Find(nvSession.Role);
                if (role != null && (Role == null || Role.Contains(role.RoleName)))
                {
                    // nếu Role của người dùng nằm trong danh sách Role 
                    // thì cho phép tất cả quyền 
                    return;
                }
                else if (nvSession.Role == 2)
                {
                    // role = 2 là user thì về homeuser.
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult
                     (
                        new RouteValueDictionary
                        (new
                        {
                            controller = "AdminHome",
                            action = "ChuyenVeUserHome",
                            returnUrl = returnUrl.ToString()
                        }));
                    return;
                }
                else
                {
                    // không có quyền bao loi
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult
                     (
                        new RouteValueDictionary
                        (new
                        {
                            controller = "AdminHome",
                            action = "BaoLoi",
                            returnUrl = returnUrl.ToString()
                        }));
                    return;
                }
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult
                 (
                    new RouteValueDictionary
                    (new
                    {
                        controller = "AdminHome",
                        action = "Login",
                        returnUrl = returnUrl.ToString()
                    }));
            }
        }
    }
}