using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.Models;
using HiveData.Repository;
using HiveServices.IService;
using HiveServices.Service;
using System.IO;
using HiveData.ViewModels;
using System.Data.Entity;

namespace Cinehive.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly CineHiveContext context = new CineHiveContext();
        private IAlbumService albumService;

        public AlbumController()
        {
            albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.AlbumUserId = userId;
            return View(albumService.GetAlbums(userId));
        }

        [Authorize]

        public ActionResult Create(string input1, string input2)
        {
            var userid = User.Identity.GetUserId();
            UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userid);
            var result = userProfile.Albums.Count();

            try
            {
                if (ModelState.IsValid)
                {
                    if (result >= 15)
                    {
                        return Content("Max amount of albums in use");
                    }
                    else
                    {
                        albumService.CreateAlbum(input1, input2);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ViewAlbum(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            Album album = context.Albums.Find(id);

            AlbumImageViewModel albumImageViewModel = new AlbumImageViewModel
            {
                Images = context.Albums.Find(id).Images.ToList(),
                Album = album
            };
            TempData["Page"] = id;
            
            UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userId);
            if (userProfile.Albums.ToList().Contains(album))
            {
                ViewBag.IsUser = true;
            }
            else
            {
                ViewBag.IsUser = false;
            }
            
            return View(albumImageViewModel);
        }

        [Authorize]
        public ActionResult AddImageToAlbum(Album album, int id) //add to data and service
        {
            try
            {
                if (ModelState.IsValid)
                {
                    albumService.AddImageToAlbum(album, id);

                    
                }

                return RedirectToAction("ViewAlbum", new { id = TempData["Page"] });
            }
            catch
            {
                return View();
            }
        }

        [Authorize]

        public ActionResult DeleteImageFromAlbum(int id) //add to data and service
        {
            try
            {
                albumService.DeleteImageFromAlbum(id);
            }
            catch
            {

                return View();
            }

            return RedirectToAction("ViewAlbum",new {id = TempData["Page"] });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {

            return View(albumService.GetAlbum(id));
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    albumService.EditAlbum(album);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]

        public ActionResult DeleteAlbum(int id)
        {
            try
            {
                albumService.DeleteImagesInAlbum(id);

                albumService.DeleteAlbum(id);
           
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [Authorize]
        public ActionResult SetAsProfilePicture(Image image)
        {
            try
            {
                albumService.SetAsProfilePicture(image);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index", "Profile");
        }

        public ActionResult ViewImage(int id, bool isUser)
        {
            var result = context.Images.Find(id);
            
            ViewBag.IsUser = isUser;
              
            return View(result);
        }
    }
}
