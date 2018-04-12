﻿
using M8_C11_w01.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M8_C8_W01.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.Identity.Name!=null)
            { 
            if (User.Identity.IsAuthenticated)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var a= User.Identity.GetUserId() ;
                if (User.Identity.GetUserId() !="")
                {


                    var user = userManager.FindById(User.Identity.GetUserId());
                    string[] roles = userManager.GetRoles(User.Identity.GetUserId()).ToArray();

                    if (roles.Length > 0)
                    {
                        var r = roles[0];
                        ViewBag.uLinks = db.UserAccesss.Where(u => u.RoleName == r).ToList();
                    }
                }
            }
            }
            return View();
        }
        public ActionResult Chat()
        {
            return View("get");
        }
        public PartialViewResult  ReqtoAddGroup()
        {
            string vname = "";

            var user = db.RequestInfos.Where(u => u.UserName.Equals(User.Identity.Name) && u.Approved.Equals(true)).SingleOrDefault();
            if(user!=null)
            {
                vname = "Messagesend";
            }
            else
            {
                vname = "AddGroup";
                ViewBag.GroupName = new SelectList(db.GroupInfos.ToList(), "GroupName", "GroupName");
            }

            return PartialView(vname);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}