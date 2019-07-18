using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class categoryRepo : genericRepo<tblCategory>
    {
        public categoryRepo(KEY_TeamMVCEntities db)
            : base(db) { }

        public string getCategoryName(int id)
        {
            if (get(id) != null)
            {
                return get(id).CategoryName;
            }
            else
            {
                return "no such product";
            }
        }
        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }
    }
}