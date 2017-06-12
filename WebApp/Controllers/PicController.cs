using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PicController : Controller
    {
        //
        // GET: /Pic/

        public ViewResult Index()
        {
            return View();
        }
        public ContentResult FileLoad()
        {
            HttpPostedFileBase file = Request.Files["picFile"];
            string name = file.FileName;
            // string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.GetExtension(name);
            string[] strs = { "one", "two", "three", "four", "five", "six", "seven" };
            Random random = new Random();
            int r = random.Next(7);
            //int i = r % strs.Length;
            string getStr = strs[r];
            return Content(getStr);
        }
    }
}
