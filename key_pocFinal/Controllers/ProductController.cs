using key_pocFinal.DBEntity;
using key_pocFinal.Repository;
using key_pocFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace key_pocFinal.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        static productList listEngine;
        protected static List<tblProduct> productList;
        public ActionResult list()
        {
            listEngine = TempData["outputList"] as productList;
            if (listEngine.getSubcategoryID() != 0)
            {
                listEngine.setPropertyList(listEngine.getSubcategoryID());
                listEngine.setSubcategoryName();
                productList = listEngine.getProductsList();
            }
            return View(listEngine);
        }

        public ActionResult clearFilter()
        {
            int subID = listEngine.getSubcategoryID();
            productList newPD = new productList(new unitOfWork(new KEY_TeamMVCEntities()));
            List<tblProduct> displays = newPD.getUOW().getProductRepo().Find(e => e.ProductSubCategoryID == subID).ToList();
            newPD.setDisplayList(displays);
            newPD.setSubcategoryID(subID);
            TempData["outputList"] = newPD;
            return RedirectToAction("list", "Product");
        }

        [HttpPost]
        public ActionResult compareProducts(FormCollection fc)
        {
            //listEngine = TempData["outputList"] as productList;
            productCompare pc = new productCompare(new unitOfWork(new KEY_TeamMVCEntities()));
            List<tblProduct> list = new List<tblProduct>();
            //var id1 = fc.GetValue("product1").AttemptedValue;
            //var id2 = fc.GetValue("product2").AttemptedValue;
            //var id3 = fc.GetValue("product3").AttemptedValue;
            foreach (var product in productList)
            {
                if (fc.GetValue("product" + product.ID).AttemptedValue.Contains("true"))
                {
                    list.Add(pc.getUOW().getProductRepo().get(product.ID));
                }
            }
            pc.setCompareList(list);
            TempData["compareList"] = pc;
            return RedirectToAction("compare", "Compare");
        }

        public ActionResult displayProduct(int id)
        {
            productDetails pd = new productDetails(new unitOfWork(new KEY_TeamMVCEntities()));
            pd.setProduct(pd.getProductByID(id));
            TempData["displayProduct"] = pd;
            return RedirectToAction("details", "Details");
        }

        [HttpPost]
        public ActionResult filter(FormCollection fc)
        {
            productList newPD = new productList(new unitOfWork(new KEY_TeamMVCEntities()));
            newPD.setSubcategoryID(listEngine.getSubcategoryID());
            int startYear;
            string syear = fc.GetValue("startYear").AttemptedValue;
            if (fc.GetValue("startYear").AttemptedValue != "" && Convert.ToInt32(fc.GetValue("startYear").AttemptedValue) != 0)
            {
                startYear = Convert.ToInt32(fc.GetValue("startYear").AttemptedValue);
            }
            else
            {
                startYear = 0;
            }
            int endYear;// = Convert.ToInt32(fc.GetValue("endYear").AttemptedValue);
            if (fc.GetValue("endYear").AttemptedValue != "" && Convert.ToInt32(fc.GetValue("endYear").AttemptedValue) != 0)
            {
                endYear = Convert.ToInt32(fc.GetValue("endYear").AttemptedValue);
            }
            else
            {
                endYear = 0;
            }
            List<string> propertyList = listEngine.getFilterProperties();
            if (startYear != 0 && endYear != 0 && endYear >= startYear)
            {
                newPD.tsfilter.Add("ModelYear", new int[] { startYear, endYear });
            }
            for (int i = 1; i <= propertyList.Count; i++)
            {
                newPD.tsfilter.Add(propertyList[i - 1], new int[] { Convert.ToInt32(fc.GetValue("minAmount_" + i.ToString()).AttemptedValue), Convert.ToInt32(fc.GetValue("maxAmount_" + i.ToString()).AttemptedValue) });
            }
            newPD.setDisplayList(newPD.getProductsByFilter(newPD.getSubcategoryID(), (Dictionary<string, int[]>)newPD.tsfilter));
            TempData["outputList"] = newPD;
            return RedirectToAction("list", "Product");
        }
    }
}