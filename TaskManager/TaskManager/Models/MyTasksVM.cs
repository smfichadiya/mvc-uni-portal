using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class MyTasksVM
    {
        public Students Students { get; set; }
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Tasks> Tasks { get; set; }
    }
}