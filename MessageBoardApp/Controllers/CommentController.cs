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
using MessageBoardApp.Services.PostComment;

namespace MessageBoardApp.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {

        private PostCommentService commentService;

        public CommentController()
        {
            this.commentService = new PostCommentService();
        }


        public ActionResult Index()
        {
            var allcommentsforpost = this.commentService.GetComments();

            return View(allcommentsforpost);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            comment.Author = this.HttpContext.User.Identity.Name;

            this.commentService.SaveComment(comment);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var result = this.commentService.GetCommentById(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            this.commentService.DeleteComment(id);
            return RedirectToAction("Index", "Comment");

        }


    }
}