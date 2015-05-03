﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoardApp.Models
{
    public class Thread
    {

        public int ThreadId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }


    }
}