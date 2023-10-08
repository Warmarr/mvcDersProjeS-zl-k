using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;

namespace mvcDers.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public ActionResult Index()
        {
            
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            var x = (string)Session["AdminUserName"];
            var messageCount = messageManager.GetUnReadMessage(x).Count().ToString();
            ViewBag.MCount = messageCount;
            return PartialView();
        }
    }
}