using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace dotnet_cloudinary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/images"), _FileName);
                file.SaveAs(_path);

                var myAccount = new Account { ApiKey = "457141667853418", ApiSecret = "6QTXwDrXNFTTHrhg2XajW-nJbxk", Cloud = "nonefd" };
                Cloudinary _cloudinary = new Cloudinary(myAccount);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(_path)
                };
                var uploadResult = _cloudinary.Upload(uploadParams);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}