using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }


        public int ThreadId { get; set; }
       
    }
}