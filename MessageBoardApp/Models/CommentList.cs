using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Models
{
    public class CommentList
    {
        public int ThreadId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}