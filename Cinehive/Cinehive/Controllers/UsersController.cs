using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HiveData.Models.Domain;
using HiveData.Models.Repository;

namespace Cinehive.Controllers
{
    public class UsersController : Controller
    {
        private HiveContext db = new HiveContext();

        public ActionResult Index() //Use to initilise database
        {
            return View(db.Users.ToList());
        }
    }
}
