using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDers.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var headinglist = headingManager.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}