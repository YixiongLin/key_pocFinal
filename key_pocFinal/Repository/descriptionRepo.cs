using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class descriptionRepo : genericRepo<tblProductDescription>
    {
        public descriptionRepo(KEY_TeamMVCEntities db)
            : base(db) { }
        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }
    }
}