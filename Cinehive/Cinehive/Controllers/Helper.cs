using HiveData.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinehive.Controllers
{
    public class Helper
    {
        private HttpContext httpContext;

        public Helper()
        {
            httpContext = HttpContext.Current;
        }

        public void CheckSession()
        {
            //var roleStore = new RoleStore<IdentityRole>(new CineHiveContext());
            //var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(new CineHiveContext());
            var userManager = new UserManager<ApplicationUser>(userStore);
            // if user is logged in
            if (httpContext.User.Identity.IsAuthenticated)
            {
                string userId = httpContext.User.Identity.GetUserId();
                if (httpContext.Session["UserId"] == null || httpContext.Session["Roles"] == null)
                {
                    // set session data
                    httpContext.Session["UserId"] = userId;
                    httpContext.Session["Roles"] = userManager.GetRoles(userId);
                }
                
            }
        }
    }
}