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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EFContentDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public ActionResult ContentByHeading()
        {
            int id;
            string p;
            p = (string)Session["WriterMail"];            
            id = writerManager.GetWriterId(p);
            var contentvalues = contentManager.GetListByWriter(id);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mail = (string)Session["WriterMail"];
            int id = writerManager.GetWriterId(mail);
            content.ContentStatus = true;
            content.WriterID = id;
            contentManager.ContentAdd(content);
            return RedirectToAction("ContentByHeading");
        }
    }
}