using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp.Helper;
using WebApp.Models.SharedEntities;

namespace WebApp.Filters
{
    public class MVCUserAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            SE_Users Users = SessionHandler.UserDetails as SE_Users;
            if (Users.RoleCode != GlobalVariables.Shared.UserRole)
            {
                var values = new RouteValueDictionary(new { action = GlobalVariables.Shared.Unauthorized, controller = "Error" });
                filterContext.Result = new RedirectToRouteResult(values);
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}