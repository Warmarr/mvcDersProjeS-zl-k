using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var category = cm.GetCategoryList();
            return View(category);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CatigoryValidatior catvalid = new CatigoryValidatior();
            ValidationResult validationResult = catvalid.Validate(c);
            if (validationResult.IsValid)
            {
                cm.CategoryAdd(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetById(id);
            cm.CategoryDelete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = cm.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            cm.CategoryUpdate(c);
            return RedirectToAction("Index");
        }
   
    }
}