using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.ViewModels;
using Microsoft.AspNet.Identity;
using HiveData.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using PagedList;

namespace Cinehive.Controllers
{

    public class FeedController : Controller
    {
        private readonly CineHiveContext context = new CineHiveContext();
        public ViewResult Index(int? page = 1)
        {

            var Posts = context.Posts.Select(c => c);
            Posts = context.Posts.OrderBy(c => c.DatePosted);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(Posts.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GiveAward(int id)
        {
            Post post = context.Posts.Find(id);

            post.Awards++;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}