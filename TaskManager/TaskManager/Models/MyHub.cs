using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TaskManager.Models
{
    public class MyHub : Hub
    {
        public void sendMessage(string name)
        {
            Clients.All.getMessage(name);
        }
        public void Help(string studentName, string message)
        {
            Clients.All.askForHelp(studentName, message);
        }

        public void Response(string admin, string message)
        {
            Clients.All.answer(admin, message);
        }

    }
}