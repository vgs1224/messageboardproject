﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageBoardApp.Data;
using MessageBoardApp.Models;
using MessageBoardApp.Services.PostThread;

namespace MessageBoardApp.Controllers
{
    [Authorize]
    public class ThreadController : Controller
    {
        private PostThreadService threadService;

        public ThreadController()
        {
            this.threadService = new PostThreadService();
        }

        
        public ActionResult Index()
        {
            var allthreads = this.threadService.GetThreads();

            return View(allthreads);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            thread.Author = this.HttpContext.User.Identity.Name;

            this.threadService.SaveThread(thread);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var result = this.threadService.GetThreadById(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            this.threadService.DeleteThread(id);
            return RedirectToAction("Index", "Thread");

        }

       
    }
}
