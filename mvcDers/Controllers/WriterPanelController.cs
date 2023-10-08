using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace mvcDers.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager cmanager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());

        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            int id = writerManager.GetWriterId(p);
            var headings = headingManager.GetListByWriter(id);
            return View(headings);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cmanager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
  
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            var p = (string)Session["WriterMail"];
            int id = writerManager.GetWriterId(p);
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = id;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cmanager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            var headingvalue = headingManager.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetById(id);
            headingvalue.HeadingStatus = false;
            headingManager.HeadingUpdate(headingvalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int page = 1)
        {

            var heading = headingManager.GetList().ToPagedList(page,10);
            return View(heading);
        }
        [HttpGet]
        public ActionResult MyProfile()
        {
            var mail = (string)Session["WriterMail"];
            var id = writerManager.GetWriterId(mail);
            var writerInfo = writerManager.GetById(id);
            return View(writerInfo);
        }
        [HttpPost]
        public ActionResult MyProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            if(result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("MyProfile");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}