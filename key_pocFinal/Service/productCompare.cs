using key_pocFinal.DBEntity;
using key_pocFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Service
{
    public class productCompare
    {
        protected unitOfWork uow;
        protected List<tblProduct> products;
        protected tblProduct product;
        protected string categoryName;
        protected string subcategoryName;
        public productCompare(unitOfWork Uow)
        {
            uow = Uow;
        }

        public void setCompareList(List<tblProduct> list)
        {
            products = list;
        }
        
        public void setCategoryName()
        {
            categoryName = uow.getCategoryRepo().getCategoryName(uow.getSubCategoryRepo().getCategoryID(products[0].ProductSubCategoryID));
        }

        public void setSubcategoryName()
        {
            subcategoryName = uow.getSubCategoryRepo().getSubcategoryNameByID(products[0].ProductSubCategoryID);
        }

        public string getCategoryName()
        {
            return categoryName;
        }

        public string getSubcategoryName()
        {
            return subcategoryName;
        }
        public List<tblProduct> getCompareList()
        {
            return products;
        }

        public unitOfWork getUOW()
        {
            return uow;
        }
    }
}