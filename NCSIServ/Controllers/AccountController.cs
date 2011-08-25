using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using NCSIServ.Models;

namespace NCSIServ.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            bool allow = true;
            if (model.UserName.Contains("-"))
            {
                allow = false;
                ModelState.AddModelError("", "Usernames cannot contain a - character");
            }
            if (allow && ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public class AccessData
        {
            public string Address;
            public DateTime Time;
        }

        //[Authorize]
        //public ActionResult Log()
        //{
        //    Models.ncsi_site_dbEntities _db = new ncsi_site_dbEntities();
        //    string name = Membership.GetUser().UserName;
        //    var accesses = _db.AccessLogs.Where(m => m.username == name).Select(m => new AccessData { Address = m.address, Time = m.datetime }).OrderByDescending(a => a.Time).Take(20);
        //    ViewData["Accesses"] = accesses;
        //    ViewData["page"] = 0;
        //    return View();
        //}

        [Authorize]
        public ActionResult Log(int id = 0)
        {
            Models.ncsi_site_dbEntities _db = new ncsi_site_dbEntities();
            string name = Membership.GetUser().UserName;
            var accesses = _db.AccessLogs.Where(m => m.username == name).Select(m => new AccessData { Address = m.address, Time = m.datetime }).OrderByDescending(a => a.Time).Skip(id * 20).Take(20);
            ViewData["Accesses"] = accesses;
            ViewData["page"] = id;
            return View();
        }

        [Authorize]
        public ActionResult Delete()
        {
            Models.ncsi_site_dbEntities _db = new ncsi_site_dbEntities();
            string name = Membership.GetUser().UserName;
            foreach (var log in _db.AccessLogs.Where(m => m.username == name))
            {
                _db.DeleteObject(log);
            }
            _db.SaveChanges();
            return RedirectToAction("Log", "Account");
        }

        [Authorize]
        public ActionResult Registry()
        {
            ViewData["Username"] = Membership.GetUser().UserName;
            return View();
        }
    }
}
