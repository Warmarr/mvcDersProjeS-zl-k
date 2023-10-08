using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        RoleManager roleManager = new RoleManager(new EFRoleDal());

        public ActionResult Index()
        {
            var values = adminManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var values = adminManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin c)
        {
            adminManager.AdminUpdate(c);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id) 
        {
            var values = adminManager.GetByID(id);
            if(values.AdminStatus == true)
            {
                values.AdminStatus = false;
                adminManager.AdminUpdate(values);
            }
            else
            {
                values.AdminStatus = true;
                adminManager.AdminUpdate(values);

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminRoleEdit(int id)
        {
            List<SelectListItem> rolevalues = (from x in roleManager.GetRoles()
                                               select new SelectListItem
                                               {
                                                   Text = x.RoleName,
                                                   Value = x.RoleId.ToString()
                                               }
                                               ).ToList();
            ViewBag.role = rolevalues;
            var value = adminManager.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminRoleEdit(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }

    }
}