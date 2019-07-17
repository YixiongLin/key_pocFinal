using key_pocFinal.DBEntity;
using key_pocFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Service
{
    public class productDetails
    {
        protected unitOfWork uow;
        protected tblProduct myProduct;

        public productDetails(unitOfWork Uow)
        {
            uow = Uow;
        }

        public void setProduct(tblProduct product)
        {
            myProduct = product;
        }

        public tblProduct getProduct()
        {
            return myProduct;
        }

        public tblProduct getProductByID(int id)
        {
            return uow.getProductRepo().get(id);
        }
    }
}