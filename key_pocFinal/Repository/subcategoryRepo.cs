using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class subcategoryRepo : genericRepo<tblSubCategory>
    {
        public subcategoryRepo(KEY_TeamMVCEntities db)
            : base(db) { }

        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }

        public IEnumerable<tblSubCategory> getByPrefix(string prefix)
        {
            return _dbContext.Set<tblSubCategory>().Where(x => x.SubCategoryName.Contains(prefix));
        }

        public string getSubcategoryNameByID(int id)
        {
            if (Find(e => e.SubCategoryID == id).ToList().Count > 0)
            {
                return Find(e => e.SubCategoryID == id).ToList()[0].SubCategoryName;
            }
            else
            {
                return "No Such Subcategory!";
            }
        }

        public int getCategoryID(int sid)
        {
            return get(sid).CategoryID;
        }
    }
}