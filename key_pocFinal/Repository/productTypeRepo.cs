using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class productTypeRepo : genericRepo<tblProductType>
    {
        public productTypeRepo(KEY_TeamMVCEntities db)
            : base(db) { }

        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }
    }
}