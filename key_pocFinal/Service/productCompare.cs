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
        public productCompare(unitOfWork Uow)
        {
            uow = Uow;
        }

        public void setCompareList(List<tblProduct> list)
        {
            products = list;
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