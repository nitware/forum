using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Forum.Domain.Entities;

namespace Forum.UI.Controllers
{
    public abstract class BaseController : Controller
    {
     
        public static User LoggedInUser { get; set; }
        public static bool IsAuthenticated { get; set; }

        public void Authenticated(bool authenticated, User user = null)
        {
            if (authenticated)
            {
                IsAuthenticated = true;
                LoggedInUser = user;
            }
            else
            {
                IsAuthenticated = false;
                LoggedInUser = null;
            }
        }



    }

}