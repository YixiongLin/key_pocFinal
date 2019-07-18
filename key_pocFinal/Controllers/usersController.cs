using key_pocFinal.DBEntity;
using key_pocFinal.Models;
using key_pocFinal.Repository;
using key_pocFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace key_pocFinal.Controllers
{
    public class usersController : Controller
    {
        // GET: users
        productSearch searchEngine = new productSearch(new unitOfWork(new KEY_TeamMVCEntities()));
        protected static int selectedCategoryID;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(user objUser)
        {
            using (KEY_TeamMVCEntities db = new KEY_TeamMVCEntities())
            {
                var userDetails = db.tblUsers.Where(x => x.UserName == objUser.UserName && x.Passcode == objUser.Passcode).FirstOrDefault();
                if (userDetails == null)
                {
                    objUser.LoginErrorMessage = "Wrong username or password";
                    return View("Index", objUser); ;
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Search", "users");
                }
            }
        }

        public ActionResult LogOut()
        {
            //int userID = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "users");
        }

        public ActionResult register()
        {
            return RedirectToAction("Register", "Account");
        }

        public ActionResult Search()
        {
            return View(searchEngine);
        }

        public JsonResult GetSubcategories(string Prefix)
        {
            List<subcategoryModel> allsearch;
            if (selectedCategoryID == 0)
            {
                allsearch = searchEngine.getSubcategoryByPrefix(Prefix).Select(x => new subcategoryModel
                {
                    CategoryID = x.CategoryID,
                    SubCategoryID = x.SubCategoryID,
                    SubCategoryName = x.SubCategoryName
                }).ToList();
            }
            else
            {
                allsearch = searchEngine.getByCategoryAndPrefix(Prefix, selectedCategoryID).Select(x => new subcategoryModel
                {
                    CategoryID = x.CategoryID,
                    SubCategoryID = x.SubCategoryID,
                    SubCategoryName = x.SubCategoryName
                }).ToList();
            }
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult getSelectedCategory(int id)
        {
            selectedCategoryID = id;
            return View("Search", searchEngine);
        }

        [HttpPost]
        public ActionResult displayProductList(string userInputValue)
        {
            string a = userInputValue;
            List<tblProduct> outputList = searchEngine.getProductBySubcategoryName(userInputValue);
            productList pl = new productList(new unitOfWork(new KEY_TeamMVCEntities()));
            pl.setDisplayList(outputList);
            pl.setSubcategoryID(searchEngine.getSubcategoryIDByName(userInputValue));
            TempData["outputList"] = pl;
            return RedirectToAction("list", "Product");
        }
    }
}