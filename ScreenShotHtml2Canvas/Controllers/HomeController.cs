using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenShotHtml2Canvas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScreenShot(FormCollection formCollection)
        {
            string screenShot = formCollection["capturedShot"];
            //remove the image header details
            string trimmedData = screenShot.Replace("data:image/png;base64,", "");

            //convert the base 64 string image to byte array
            byte[] uploadedImage = Convert.FromBase64String(trimmedData);

            //the byte array can be saved into database or on file system
            //saving the image on the server
            string fileName = Guid.NewGuid() + ".png";
            string path = Server.MapPath("~/App_Data/" + fileName);
            System.IO.File.WriteAllBytes(path, uploadedImage);
            return View("Index");
        }
       
    }
}