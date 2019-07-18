using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace key_pocFinal.Models
{
    public class UserRegister
    {
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [Display(Name = "UserName: ")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address: ")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Passcode { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [Display(Name = "Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare("Passcode", ErrorMessage = "Password and Confirm Password must be same.")]
        public string ConfirmPasscode { get; set; }


        public string UrlImage { get; set; }

        [Display(Name = "Upload Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}