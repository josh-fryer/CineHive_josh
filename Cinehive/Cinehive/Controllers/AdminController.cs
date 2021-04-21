using HiveData.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveServices.Service;
using HiveServices.IService;

namespace Cinehive.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public class AdminController : Controller
    {
        private CineHiveContext context;
        private IAdminService adminService;

        public AdminController()
        {
            context = new CineHiveContext();
            adminService = new AdminService();
        }
        
        public ActionResult BanUser(string id)
        {
            // create ApplicationUserManager obj
            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
            // get all roles for user
            string[] roles = um.GetRoles(id).ToArray();
            um.RemoveFromRoles(id, roles); // remove user from all roles
            // Add user to banned role
            um.AddToRole(id, "Banned");

            // delete posts
            adminService.RemoveUserPosts(id);

            return RedirectToAction("Index", "Home");
        }
    }
}