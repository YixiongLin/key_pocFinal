using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace key_pocFinal.Models
{
    public partial class user
    {
        public int UserID { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Passcode { get; set; }
        public string UrlImage { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}