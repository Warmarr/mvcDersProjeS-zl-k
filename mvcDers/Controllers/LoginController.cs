using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcDers.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager alogmanager = new AdminLoginManager(new EFAdminLogin());
        WriterLoginManager WriterLoginManager = new WriterLoginManager(new EFWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult AdminLoginPage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLoginPage(Admin admin)
        {
            var valuesAdmin = alogmanager.GetAdmin(admin.AdminUserName, admin.AdminPassword);
            if(valuesAdmin != null)
            {
                FormsAuthentication.SetAuthCookie(valuesAdmin.AdminUserName, false);
                Session["AdminUserName"] = valuesAdmin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                TempData["hata"] = " ";
                return RedirectToAction("AdminLoginPage");
            }

            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var valuesWriter = WriterLoginManager.GetWriter(writer.WriterMail,writer.WriterPassword);
            if (valuesWriter != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterName, false);
                Session["WriterMail"] = writer.WriterMail;
                return RedirectToAction("ContentByHeading", "WriterPanelContent");
            }
            else
            {
                TempData["hata"] = " ";
                return RedirectToAction("WriterLogin");
            }

            return View();

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
        public PartialViewResult LoginErrorPartial()
        {
            return PartialView();
        }

    }
}