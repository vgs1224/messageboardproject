﻿using MessageBoardApp.Models;
using MessageBoardApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MessageBoardApp.Controllers
{
    public class AccountController : Controller
    {

        private IUserService userService;

        public AccountController()
        {
            var encryptor = new SHA256Encryptor();
            this.userService = new UserService(encryptor);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            bool isAuthenticated = this.userService.Authenticate(model.Username, model.Password);

            if (isAuthenticated)
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Invalid username or password");

                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool exists = this.userService.Exists(user.Username);

            if (exists)
            {
                this.ModelState.AddModelError("", "Username already exists");
                return View();
            }


            try
            {
                this.userService.Register(user);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", "An error has occured");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}