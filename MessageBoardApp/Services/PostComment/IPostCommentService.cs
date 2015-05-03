using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoardApp.Models;

namespace MessageBoardApp.Services
{
    public interface IPostCommentService
    {
        List<Comment> GetComments();

        Comment GetCommentsById(int id);

        void SaveComment(Comment comment);

        void DeleteComment(int id);
    }
}
