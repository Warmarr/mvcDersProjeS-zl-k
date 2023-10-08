using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using mvcDers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CateogryChart() 
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<Category> BlogList()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            list.Add(new Category()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            list.Add(new Category()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            list.Add(new Category()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return list;
        }
        public ActionResult HeadingChart()
        {
            return View();
        }
        public ActionResult HeadingsContentChart()
        {
            return Json(HeadingsContent(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingsContent> HeadingsContent()
        {
            List<HeadingsContent> headingsContents = new List<HeadingsContent>();
            using(var c = new Context())
            {
                headingsContents = c.Headings.Select(x=> new HeadingsContent
                {
                    HeadingName = x.HeadingName,
                    ContentCount = x.Contents.Count()
                }).ToList();
            }
            return headingsContents;
        }
        public ActionResult WriterChartHeadingCount()
        {
            return View();
        } 
        public ActionResult WriterCountChart()
        {
            return Json(headingWriterCounts(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingWriterCount> headingWriterCounts() 
        {
            List<HeadingWriterCount> writerCounts = new List<HeadingWriterCount>();
            using(var c = new Context())
            {
                writerCounts = c.Writers.Select(x=> new HeadingWriterCount
                {
                    WriterName = x.WriterName + " " + x.WriterSurname,
                    HeadingCount = x.Headings.Count()
                }).ToList();
            }
            return writerCounts;
        }
    }
}