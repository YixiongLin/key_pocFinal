using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class productRepo : genericRepo<tblProduct>
    {
        public productRepo(KEY_TeamMVCEntities db)
            : base(db) { }
        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }

        public IEnumerable<tblSubCategory> getByPrefix(string prefix)
        {
            return _dbContext.Set<tblSubCategory>().Where(x => x.SubCategoryName.Contains(prefix));
        }

        public int getTSID(int productId)
        {
            return get(productId).ProductTecSpecID;
        }
    }
}