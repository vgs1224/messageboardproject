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
using MessageBoardApp.Services;
using MessageBoardApp.Services.PostComment;

namespace MessageBoardApp.Controllers
{

    public class CommentController : Controller
    {
        private MessageBoardAppContext db = new MessageBoardAppContext();

        private PostCommentService commentService;

        public CommentController()
        {
            this.commentService = new PostCommentService();
        }


        public ActionResult List(int id)
        {
            var commentmodel = new CommentList();

            commentmodel.ThreadId = id;
            commentmodel.Comments = this.commentService.GetCommentsByThreadId(id);

            return View(commentmodel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var comment = new Comment();
            comment.ThreadId = id;
            return View(comment);
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            comment.Author = this.HttpContext.User.Identity.Name;

            this.commentService.SaveComment(comment);
            return RedirectToAction("List", new { id = comment.ThreadId });
        }

        /*public ActionResult Details(int id)
        {
            var result = this.commentService.GetCommentsById(id);
            return View(result);
        }*/

        public ActionResult Delete(int id)
        {
            this.commentService.DeleteComment(id);
            return RedirectToAction("Index", "Threads");

        }


    }
}