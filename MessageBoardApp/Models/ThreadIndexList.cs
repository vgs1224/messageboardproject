using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Models
{
    public class ThreadIndexList
    {
        public User User { get; set; }

        public List<Thread> Thread { get; set; }
    }
}