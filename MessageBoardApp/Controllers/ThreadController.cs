using System;
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
using MessageBoardApp.Services;

namespace MessageBoardApp.Controllers
{
    [Authorize]
    public class ThreadController : Controller
    {
        private MessageBoardAppContext yep = new MessageBoardAppContext();

        private PostThreadService threadService;
        private UserService userservice;

        public ThreadController()
        {
            this.threadService = new PostThreadService();

            this.userservice = new UserService(null);
        }

        
        [HttpGet]
        public ActionResult Index()
        {

            var threadlisting = new ThreadIndexList();
            threadlisting.User = this.userservice.getUser(User.Identity.Name);
            threadlisting.Thread = this.threadService.GetThreads();


            return View(threadlisting);
       
        }

        [HttpPost]
        public ActionResult Index(string text)
        {
            string searchString = text;
            var search = new ThreadIndexList();
            search.User = this.userservice.getUser(User.Identity.Name);
            search.Thread = this.threadService.GetThreads();
        

            if (!String.IsNullOrEmpty(searchString))
            {
                search.Thread = search.Thread.Where(s => s.Title.Contains(searchString)).ToList();
            } 

            return View(search);

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
