using MessageBoardApp.Data;
using MessageBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Services.PostComment
{
    public class PostCommentService: IPostCommentService
    {
        private MessageBoardAppContext context;

        public PostCommentService()
        {
            this.context = new MessageBoardAppContext();
        }

        public List<Comment> GetComments()
        {
            return this.context.Comments.ToList();
        }

        public Comment GetCommentsById(int id)
        {
            return this.context.Comments.Where(x => x.commentId == id).SingleOrDefault();
        }

        public void SaveComment(Models.Comment comment)
        {
            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = this.context.Comments.Where(x => x.commentId == id).SingleOrDefault();
            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }

        public List<Comment> GetCommentsByThreadId(int id)
        {
            return this.context.Comments.Where(x => x.ThreadId == id).ToList();
        }
    }
}