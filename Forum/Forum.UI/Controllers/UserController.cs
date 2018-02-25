using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Forum.UI.Extensions;
using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using Forum.UI.Models;
using Forum.Domain.Models;
using System.Web.Security;
using Forum.Service;

namespace Forum.UI.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        //private readonly IMembershipService _membershipService;
        private readonly MembershipService _membershipService;
        private readonly IRepository<User> _personService;

        public UserController(MembershipService membershipService, IRepository<User> personService)
        {
            if (membershipService == null)
            {
                throw new ArgumentNullException("membershipService");
            }
            if (personService == null)
            {
                throw new ArgumentNullException("personService");
            }

            _personService = personService;
            _membershipService = membershipService;
        }

        // GET: User
        public ActionResult Index()
        {
            List<User> users = new List<User>();
            users.ToModels();

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = _membershipService.CreateUser(model.ToEntity());
                    if (user != null && user.Id > 0)
                    {
                        return RedirectToAction("Index", "Post");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel model, string returnUrl)
        {
            ModelState.Remove("Name");
            ModelState.Remove("ConfirmPassword");

            if (ModelState.IsValid)
            {
                UserContext userContext = _membershipService.ValidateUser(model.Email, model.HashedPassword);
                if (userContext != null && userContext.Principal != null)
                {
                    Authenticated(true, userContext.User);
                    FormsAuthentication.SetAuthCookie(userContext.User.Name, false);
                    
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Post");
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is invalid!");
                }
            }

            Authenticated(false);
            return View(model);
        }
              
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Authenticated(false);
            return RedirectToAction("Login", "User", new { Area = "" });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
        }



    }




}