using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class WriterMessageController : Controller
    {
        // GET: WriterMessage
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var reciever = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(reciever);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var reciever = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(reciever);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            values.IsRead = true;
            messageManager.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);            
        }
        [HttpGet]
        public ActionResult AddNewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddNewMessage(EntityLayer.Concrete.Message message)
        {
            var sender = (string)Session["WriterMail"];
            MessageValidator messagevalidator = new MessageValidator();
            ValidationResult result = messagevalidator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult MessageListMenu()
        {
            var x = (string)Session["WriterMail"];
            var messageCount = messageManager.GetUnReadMessage(x).Count().ToString();
            ViewBag.MCount = messageCount;
            return PartialView();
        }
    }
}