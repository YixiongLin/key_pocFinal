using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class tsFilterRepo : genericRepo<tblTSFilter>
    {
        public tsFilterRepo(KEY_TeamMVCEntities db)
            : base(db) { }

        public List<String> getPropertyBySubcategoryID(int subcategoryID)
        {
            List<String> output = new List<string>();
            foreach (var property in Find(e => e.SubCategoryID == subcategoryID))
            {
                if (property.IsActive == true)
                {
                    output.Add(property.PropertyName);
                }
            }
            return output;
        }

        public int getMaxValueByPropertyAndSubcategory(int subcategoryID, string property)
        {
            List<tblTSFilter> list = _dbContext.Set<tblTSFilter>().Where(e => e.SubCategoryID == subcategoryID && e.PropertyName == property).ToList();
            if (list.Count > 0)
            {
                return list[0].Max;
            }
            else
            {
                return -1;
            }

        }
        public int getMinValueByPropertyAndSubcategory(int subcategoryID, string property)
        {
            List<tblTSFilter> list = _dbContext.Set<tblTSFilter>().Where(e => e.SubCategoryID == subcategoryID && e.PropertyName == property).ToList();
            if (list.Count > 0)
            {
                return list[0].Min;
            }
            else
            {
                return -1;
            }

        }
        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }
    }
}