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
            return View(albumService.GetAlbums().ToList());
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            var userid = User.Identity.GetUserId();
            UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userid);
            var result = userProfile.Albums.Count();

            try
            {
                if (ModelState.IsValid)
                {
                    if (result >= 20)
                    {
                        return RedirectToAction("Index"); //Javascript an error window here to tell the user they have max amount of albums
                    }
                    else
                    {
                        albumService.CreateAlbum(album);
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
        public ActionResult ViewAlbum(int id)
        {

            AlbumImageViewModel albumImageViewModel = new AlbumImageViewModel
            {
                Images = context.Albums.Find(id).Images.ToList(),
                Album = context.Albums.Find(id)
            };
            TempData["Page"] = id;

            return View(albumImageViewModel);
        }
        [Authorize]
        public ActionResult AddImageToAlbum(int id)
        {
            TempData["id"] = id;

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddImageToAlbum(Album album) //add to data and service
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = Convert.ToInt32(TempData["id"]);

                    string userid = User.Identity.GetUserId();
                    string extension = Path.GetExtension(album.UploadImage.FileName);
                    string filename = string.Empty;

                    filename = userid + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + extension;
                    string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Img/UserImg/" + userid);

                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }
                    string fullPath = "Content/Img/UserImg/" + userid + "/" + filename;
                    album.UploadImage.SaveAs(Path.Combine(imagePath, filename));

                    album = context.Albums.Find(id);

                    Image image1 = new Image()
                    {
                        ImagePath = fullPath,
                        Filename = filename
                    };

                    album.Images.Add(image1);
                    context.SaveChanges();

                    
                }

                return RedirectToAction("ViewAlbum", new { id = TempData["Page"] });
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult DeleteImageFromAlbum(int id)
        {
            return View(albumService.GetImage(id));
        }
        [HttpPost]
        public ActionResult DeleteImageFromAlbum(int id, Image image) //add to data and service
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
            return View(albumService.GetAlbum(id));
        }

        [HttpPost]
        public ActionResult DeleteAlbum(int id, Album album)
        {
            try
            {
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
    }
}
