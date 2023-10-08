using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;


namespace mvcDers.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mn = new MessageManager(new EFMessageDal());

        public ActionResult Inbox()
        {
            var reciever = (string)Session["AdminUserName"];
            var messagelist = mn.GetListInbox(reciever);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var sender = (string)Session["AdminUserName"];
            var messagelist = mn.GetListSendbox(sender);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mn.GetById(id);
            values.IsRead = true;
            mn.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mn.GetById(id);
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
            var sender = (string)Session["AdminUserName"];
            MessageValidator messagevalidator = new MessageValidator();
            ValidationResult result = messagevalidator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mn.MessageAdd(message);
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

    }
}