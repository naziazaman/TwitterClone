using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Some details about Twitter Clone";

            return View();
        }

        [Authorize]
        public ActionResult TimeLine()
        {

            ViewData["Title"] = string.Format("{0} Timeline", User.Identity.Name);
            var aTimeLineData = CreateTimeLineData(User.Identity.Name, true);
            return View("Index", aTimeLineData);
        }

        public ActionResult UserTimeLine(string id)
        {
            User user;
            var result = GetUser(id, out user);
            if (result != null)
            {
                return result;
            }

            ViewData["Title"] = string.Format("{0} Userline", user.UserName);
            ViewData["User"] = user;
            IList<Tweet> userLine = Repository.GetUserLine(user.UserName);

            var timeLineData = CreateTimeLineData(user.UserName, true, userLine);
            return View("Index", timeLineData);
        }

        public ActionResult PublicTimeLine()
        {
            ViewData["Title"] = "Public Timeline";
            var timeLine = new TimeLineData { Chirps = Repository.GetPublicTimeLine() };
            return View("Index", timeLine);
        }

        public ActionResult ShowTweet(string id)
        {
            var tweet = Repository.GetTweet(id);
            if (tweet == null)
            {
                
            }

            var timelinedata = new TimeLineData
            {
                Chirps = new List<Tweet> { tweet },
                ShowIndividualChrip = true
            };
            ViewData["Title"] = "Show Tweet";
            User user = Repository.GetUser(tweet.User);
            ViewData["User"] = user;
            return View("Index", timelinedata);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tweet(string text)
        {
            Repository.AddTweet(new Tweet
            {
                Location = "Web",
                TweetMessage = text,
                User = User.Identity.Name
            });

            return TimeLine();
        }

        [Authorize]
        public ActionResult Follow(string id)
        {
            if (!Repository.Follow(User.Identity.Name, id))
            {
                
            }

            return RedirectToAction("Following");
        }

        public ActionResult Followers(string id)
        {
            User user;
            return GetUser(id, out user) ?? View(Repository.GetFollowers(user.UserName));
        }

        public ActionResult Following(string id)
        {
            User user;
            return GetUser(id, out user) ?? View(Repository.GetFollowing(user.UserName));
        }

        public ActionResult About()
        {
            return View();
        }

#endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["LoggedUser"] = Repository.GetUser(User.Identity.Name);
            }
        }

        private ActionResult GetUser(string id, out User user)
        {
            if (string.IsNullOrEmpty(id))
            {
                if (User.Identity.IsAuthenticated)
                {
                    id = User.Identity.Name;
                }
                else
                {
                    user = null;
                    return RedirectToAction("LogOn", "Account");
                }
            }

            user = Repository.GetUser(id);
            return user == null
                       ? View("Error", new ErrorInfo(string.Format("Unknown user {0}", id)))
                       : null;
        }

        public ContentResult CurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);

            }
            return Content("Unkown");
        }

        private TimeLineData CreateTimeLineData(string userName, bool isSummaryVisible = false)
        {
            IList<Tweet> timeLine = Repository.GetTimeLine(userName);
            return CreateTimeLineData(userName, isSummaryVisible, timeLine);
        }

        private TimeLineData CreateTimeLineData(string userName, bool isSummaryVisible, IList<Tweet> tweets)
        {
            IList<Tweet> timeLine = tweets;
            int followersCount = Repository.GetFollowers(userName).Count;
            int followingCount = Repository.GetFollowing(userName).Count;
            var aTimeLineData = new TimeLineData
            {
                IsSummaryVisible = isSummaryVisible,
                Chirps = timeLine,
                FollowersCount = followersCount,
                FollowingCount = followingCount
            };
            return aTimeLineData;
        }

    }
}