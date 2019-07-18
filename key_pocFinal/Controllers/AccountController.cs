using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using key_pocFinal.DBEntity;
using key_pocFinal.Models;
using key_pocFinal.Repository;

namespace key_pocFinal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly KEY_TeamMVCEntities kEY_DB = new KEY_TeamMVCEntities();

        public ActionResult Register()
        {
            UserRegister user = new UserRegister();
            ModelState.Clear();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(UserRegister user)
        {
            // The ModelState represents a collection of name and value pairs that were submitted to the server during a POST.

            // ModelState:

            // To store the value submitted to the server. 
            // Store the validation errors associated with those values.
            if (ModelState.IsValid)
            //Tells whether it is possible to bind the incoming values from the request to the model correctly.
            {

                if (kEY_DB.tblUsers.Where(m => m.Email == user.Email).FirstOrDefault() == null)
                {
                    string UserNameImage = user.UserName;
                    string ImageFileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                    string ImageExtension = Path.GetExtension(user.ImageFile.FileName);

                    string ImagePathDetails = ImageFileName + UserNameImage + ImageExtension;
                    user.UrlImage = "~/IMG/" + ImagePathDetails;   // Save this Path in Database. It is the Project Path.

                    string SaveImage = Path.Combine(Server.MapPath("~/IMG/"), ImagePathDetails);
                    user.ImageFile.SaveAs(SaveImage); // Here we save the actual Path(Full Path of the Image) in the Images folder.

                    tblUser tblUser = new tblUser();

                    // User-> Inputs from the view.
                    // tblUser -> Store thos Inputs in the database. 
                    tblUser.UserName = user.UserName;
                    tblUser.Email = user.Email;
                    tblUser.Passcode = user.ConfirmPasscode;
                    tblUser.UrlImage = user.UrlImage;

                    unitOfWork uow = new unitOfWork(kEY_DB);// Saving the Images in the Databse.
                    uow.getUserRepo().RegisterUser(tblUser);
                    kEY_DB.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "users");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email Already Exists!");
                    return View(user);

                }
            }
            return View(user);

        }
    }
}