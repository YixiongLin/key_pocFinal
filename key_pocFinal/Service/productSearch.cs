using key_pocFinal.DBEntity;
using key_pocFinal.Models;
using key_pocFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Service
{
    public class productSearch
    {
        protected unitOfWork uow;
        protected subcategoryModel sm;
        public productSearch(unitOfWork UOW)
        {
            uow = UOW;
            sm = new subcategoryModel();
        }


        public subcategoryModel getSubcategoryModel()
        {
            return sm;
        }

        public void setModelCategory(int id)
        {
            sm.CategoryID = id;
        }

        public void setModelSubcategory(string name)
        {
            sm.SubCategoryName = name;
        }

        public IEnumerable<tblCategory> getAllCategories()
        {
            return uow.getCategoryRepo().getAll();
        }
        public IEnumerable<tblSubCategory> getByCategory(int id)
        {
            return uow.getSubCategoryRepo().Find(e => e.CategoryID == id);
        }

        public IEnumerable<tblSubCategory> getSubcategoryByPrefix(string prefix)
        {
            return uow.getSubCategoryRepo().getByPrefix(prefix);
        }

        public IEnumerable<tblSubCategory> getAllSubcategories()
        {
            return uow.getSubCategoryRepo().getAll();
        }

        public IEnumerable<tblSubCategory> getByCategoryAndPrefix(string prefix, int categoryId)
        {
            return uow.getSubCategoryRepo().Find(e => e.CategoryID == categoryId).Where(x => x.SubCategoryName.Contains(prefix));
        }

        public List<tblProduct> getProductBySubcategoryName(string subcategoryName)
        {
            List<tblProduct> productList;
            List<tblSubCategory> subList = uow.getSubCategoryRepo().Find(e => e.SubCategoryName == subcategoryName).ToList();
            if (subList.Count == 0)
            {
                productList = new List<tblProduct>();

            }
            else
            {
                int subcategoryID = subList[0].SubCategoryID;
                productList = uow.getProductRepo().Find(e => e.ProductSubCategoryID == subcategoryID).ToList();
            }
            return productList;
        }

        public int getSubcategoryIDByName(string subcategoryName)
        {
            if (uow.getSubCategoryRepo().Find(e => e.SubCategoryName == subcategoryName).ToList().Count == 0)
            {
                return 0;
            }
            else
            {
                return uow.getSubCategoryRepo().Find(e => e.SubCategoryName == subcategoryName).ToList()[0].SubCategoryID;
            }
        }
    }
}