using MyFilterBubble.DAL.DTO;
using MyFilterBubble.DAL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyFilterBubble.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<FeedItemOverviewDto> feedItems = new GetFeedItemsForOverviewQuery().Execute();

            return View(feedItems);
        }

        // TODO: Finish Like/Dislike ajax calls
        public ActionResult Like(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult Dislike(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }
    }
}