using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Models
{
    public partial class subcategoryModel
    {
        public subcategoryModel() { }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryID { get; set; }

        public categoryModel cm { get; set; }
    }
}