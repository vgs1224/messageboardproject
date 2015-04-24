using MessageBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);

        void Register(User user);

        bool Exists(string username);
    }
}