using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using key_pocFinal.DBEntity;

namespace key_pocFinal.Repository
{
    public class unitOfWork : IUnitOfWork
    {
        private readonly KEY_TeamMVCEntities _dbContext;
        private static userRepo _userRepo; //{ get; }
        private static categoryRepo _categoryRepo; //{ get; }
        private static subcategoryRepo _subcategoryRepo; //{ get; }
        private static productRepo _productRepo;
        private static descriptionRepo _descriptionRepo;
        private static productTypeRepo _productTypeRepo;
        private static technicalSpecRepo _technicalSpecRepo;
        private static tsFilterRepo _tsFilterRepo;

        public unitOfWork(KEY_TeamMVCEntities db)
        {
            _dbContext = db;
            _userRepo = new userRepo(_dbContext);
            _categoryRepo = new categoryRepo(_dbContext);
            _subcategoryRepo = new subcategoryRepo(_dbContext);
            _productRepo = new productRepo(_dbContext);
            _descriptionRepo = new descriptionRepo(_dbContext);
            _productTypeRepo = new productTypeRepo(_dbContext);
            _technicalSpecRepo = new technicalSpecRepo(_dbContext);
            _tsFilterRepo = new tsFilterRepo(_dbContext);
        }

        public userRepo getUserRepo()
        {
            return _userRepo;
        }

        public categoryRepo getCategoryRepo()
        {
            return _categoryRepo;
        }

        public subcategoryRepo getSubCategoryRepo()
        {
            return _subcategoryRepo;
        }
        public productRepo getProductRepo()
        {
            return _productRepo;
        }
        //public userRepo _userRepo { get; private set; }
        //public categoryRepo _categoryRepo { get; private set; }
        //public subcategoryRepo _subcategoryRepo { get; private set; }

        public descriptionRepo getDescriptionRepo()
        {
            return _descriptionRepo;
        }

        public productTypeRepo getProductTypeRepo()
        {
            return _productTypeRepo;
        }

        public technicalSpecRepo getTechnicalSpecRepo()
        {
            return _technicalSpecRepo;
        }

        public tsFilterRepo getTsFilterRepo()
        {
            return _tsFilterRepo;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}