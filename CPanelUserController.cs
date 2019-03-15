using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Filters;
using WebApp.Helper;
using WebApp.Models.SharedEntities;

namespace WebApp.Controllers
{
    [MVCSessionFilter, MVCUserAuthorization]
    public class CPanelUserController : Controller
    {
        #region Global Variables
        SE_Users _SessionUserDetails = SessionHandler.UserDetails as SE_Users;
        #endregion

        #region Dashboard
        public ActionResult Dashboard()
        {
            try
            {
                ViewBag.DisplayModalPopup = Reusable.CheckIsFirstTimeLogin();   // Model PopUp   
                ViewBag.Menus = Reusable.BindMenus();   // Bind Menus
            }
            catch (WebException ex)
            {
                return RedirectToAction(StatusCode.ErrorPage(ex), "Error");
            }
            return View();
        }
        #endregion
    }
}