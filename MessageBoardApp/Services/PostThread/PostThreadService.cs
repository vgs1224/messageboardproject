using MessageBoardApp.Data;
using MessageBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Services.PostThread
{
    public class PostThreadService : IPostThreadService
    {
        private MessageBoardAppContext context;

        public PostThreadService()
        {
            this.context = new MessageBoardAppContext();
        }

        public List<Thread> GetThreads()
        {
            return this.context.Threads.ToList();
        }

        public Thread GetThreadById(int id)
        {
            return this.context.Threads.Where(x => x.Id == id).SingleOrDefault();
        }

        public void SaveThread(Models.Thread thread)
        {
            this.context.Threads.Add(thread);
            this.context.SaveChanges();
        }

        public void DeleteThread(int id)
        {
            var thread = this.context.Threads.Where(x => x.Id == id).SingleOrDefault();
            this.context.Threads.Remove(thread);
            this.context.SaveChanges();
        }
    }
}
  