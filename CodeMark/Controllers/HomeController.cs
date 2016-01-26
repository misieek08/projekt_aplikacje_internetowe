using CodeMark.Models;
using CodeMark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeMark.Controllers
{
    public class HomeController : Controller
    {
        IImageService _imageService;
        private CodeMarkContext db = new CodeMarkContext();

        public HomeController(IImageService imageService)
        {
            _imageService = imageService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            List<Image> model = _imageService.GetImagesList();
            return View(model);
        }

        public FileResult GetImageContent(int imageId)
        {
            byte[] result = _imageService.GetImageContent(imageId);
            return File(result, "image/jpg");
        }
 
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            bool result =_imageService.SaveImage(file);
            return RedirectToAction("Gallery");
        }
    }
}