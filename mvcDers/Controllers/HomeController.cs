using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace mvcDers.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        ContactManager contactManager = new ContactManager(new EFContactDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage() 
        {
            var headingCount = hm.GetList().Count().ToString();
            ViewBag.HCOUNT=headingCount;
            var contentCount = contentManager.GetList().Count().ToString();
            ViewBag.contentCount=contentCount;
            var writerCount = writerManager.GetList().Count().ToString();
            ViewBag.writerCount=writerCount;
            var messageCount = messageManager.GetMessages().Count().ToString();
            ViewBag.messageCount=messageCount;
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contactManager.ContactAdd(contact);
            return RedirectToAction("HomePage");
        }
    }
}