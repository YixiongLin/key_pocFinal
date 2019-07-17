using key_pocFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace key_pocFinal.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        productDetails pd;
        public ActionResult details()
        {
            pd = TempData["displayProduct"] as productDetails;
            return View(pd);
        }
    }
}