using MessageBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardApp.Services
{
    public interface IPostThreadService
    {
        List<Thread> GetThreads();

        Thread GetThreadById(int id);

        void SaveThread(Thread thread);

        void DeleteThread(int id);

    }
}
