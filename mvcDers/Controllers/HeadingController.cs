using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EFHeadingDal());
        CategoryManager cmanager = new CategoryManager(new EFCategoryDal());
        WriterManager wmanager = new WriterManager(new EFWriterDal());


        public ActionResult Index()
        {
            var headings = manager.GetList();
            return View(headings);
        }

        [HttpGet]                   
        public ActionResult AddHeading()
        {

            List<SelectListItem> valuecategory = (from x in cmanager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            List<SelectListItem> valuewriter = (from x in wmanager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.wrt = valuewriter;

            return View(); 
            

        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            manager.HeadingAdd(heading);
            return RedirectToAction("Index");
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

            var headingvalue = manager.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading) 
        { 
            manager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id) 
        {
            var headingvalue = manager.GetById(id);
            if(headingvalue.HeadingStatus == true) 
            {
                headingvalue.HeadingStatus = false;
                manager.HeadingUpdate(headingvalue);
            }
            else if(headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
                manager.HeadingUpdate(headingvalue);
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult HeadingReport()
        {
            var headings = manager.GetList();
            return View(headings);
        }
     
    }
}