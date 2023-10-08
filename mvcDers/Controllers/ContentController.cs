using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllContent()
        {
            var values = contentManager.GetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetAll(p);
            if(values == null)
            {
                return View(contentManager.GetList());
            }
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {

            var contentvalues = contentManager.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}