﻿using key_pocFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace key_pocFinal.Controllers
{
    public class CompareController : Controller
    {
        // GET: Compare
        productCompare pc;
        public ActionResult compare()
        {
            pc = TempData["compareList"] as productCompare;
            if(pc.getCompareList().Count > 0)
            {
                pc.setCategoryName();
                pc.setSubcategoryName();
            }
            return View(pc);
        }
    }
}