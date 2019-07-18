using key_pocFinal.DBEntity;
using key_pocFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Service
{
    public class productList
    {
        protected unitOfWork uow;
        protected List<tblProduct> displayList;
        //protected List<tblProduct> compareList;
        protected int subcategoryID;
        protected string subcategoryName;
        protected List<String> tsPropertyList;
        public tblProduct detailProduct;
        public int startYear;
        public int endYear;
        //public int minAmount_1, minAmount_2, minAmount_3, minAmount_4;
        //public int maxAmount_1, maxAmount_2, maxAmount_3, maxAmount_4;
        public IDictionary<string, int[]> tsfilter = new Dictionary<string, int[]>();

        public productList() { }
        public productList(unitOfWork Uow)
        {
            uow = Uow;
            displayList = new List<tblProduct>();
        }

        public unitOfWork getUOW()
        {
            return uow;
        }

        public int getSubcategoryID()
        {
            return subcategoryID;
        }

        public string getSubcategoryName()
        {
            return subcategoryName;
        }
        public void setSubcategoryID(int sid)
        {
            subcategoryID = sid;
        }

        public void setDisplayList(List<tblProduct> list)
        {
            displayList = list;
        }

        public List<tblProduct> getCompareList(int[] compareIDs)
        {
            List<tblProduct> list = new List<tblProduct>();
            foreach (int id in compareIDs)
            {
                list.Add(uow.getProductRepo().get(id));
            }
            return list;
        }

        public List<tblProduct> getProductsList()
        {
            return displayList;
        }

        public void setPropertyList(int sid)
        {
            tsPropertyList = uow.getTsFilterRepo().getPropertyBySubcategoryID(sid);
        }

        public List<String> getPropertyList()
        {
            return tsPropertyList;
        }

        public List<string> getPropertyListByID(int id)
        {
            return uow.getTsFilterRepo().getPropertyBySubcategoryID(id);
        }
        public void setSubcategoryName(string name)
        {
            subcategoryName = name;
        }

        public int getMaxValue(int subcategoryID, string property)
        {
            return uow.getTsFilterRepo().getMaxValueByPropertyAndSubcategory(subcategoryID, property);
        }

        public int getMinValue(int subcategoryID, string property)
        {
            return uow.getTsFilterRepo().getMinValueByPropertyAndSubcategory(subcategoryID, property);
        }

        public string getCategoryNameBySubID(int sid)
        {
            int categoryID = uow.getSubCategoryRepo().getCategoryID(sid);
            string categoryName = uow.getCategoryRepo().getCategoryName(categoryID);
            return categoryName;
        }

        public List<String> getFilterProperties()
        {
            int index = 1, count = 0;
            List<String> output = new List<string>();
            while (index < 5 && count < getPropertyList().Count)
            {
                if (getPropertyList()[count].Contains("Min") == false)
                {
                    output.Add(getPropertyList()[count]);
                    index++;
                }
                count++;
            }
            return output;
        }

        public List<string> getFilterPropertiesByID(int subcategoryID)
        {
            int index = 1, count = 0;
            List<String> output = new List<string>();
            while (index < 5 && count < getPropertyListByID(subcategoryID).Count)
            {
                if (getPropertyListByID(subcategoryID)[count].Contains("Min") == false)
                {
                    output.Add(getPropertyListByID(subcategoryID)[count]);
                    index++;
                }
                count++;
            }
            return output;
        }

        public double getPropertyValue(int productID, string property)
        {
            return uow.getTechnicalSpecRepo().getTSPropertyValue(productID, property);
        }

        public tblProduct getProductByID(int id)
        {
            return uow.getProductRepo().get(id);
        }

        public void clearFilterDictionary()
        {
            tsfilter.Clear();
        }

        public List<tblProduct> getProductsByFilter(int subcategoryID, Dictionary<string, int[]> filter)
        {
            List<tblProduct> output = uow.getProductRepo().Find(e => e.ProductSubCategoryID == subcategoryID).ToList();
            List<string> properties = getFilterPropertiesByID(subcategoryID);
            List<int> filterProductIds = new List<int>();
            for (int i = 0; i < output.Count; i++)
            {
                var product = output[i];
                if (filter.ContainsKey("ModelYear"))
                {
                    if(product.tblProductType != null)
                    {
                        if (Convert.ToInt32(product.tblProductType.ModelYear) < filter["ModelYear"][0] || Convert.ToInt32(product.tblProductType.ModelYear) > filter["ModelYear"][1])
                        {
                            filterProductIds.Add(product.ID);
                        }
                    }
                }
                //Dictionary<double, int[]> map = new Dictionary<double, int[]>();
                foreach (var property in properties)
                {
                    //map.Add(getPropertyValue(product.ID, property), filter[property]);
                    if (getPropertyValue(product.ID, property) < filter[property][0] || getPropertyValue(product.ID, property) > filter[property][1])
                    {
                        filterProductIds.Add(product.ID);
                    }
                }
            }
            foreach (int a in filterProductIds)
            {
                output.RemoveAll(e => e.ID == a);
            }
            return output;
        }
    }
}