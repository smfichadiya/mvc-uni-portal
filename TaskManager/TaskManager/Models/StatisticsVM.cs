using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class StatisticsVM
    {
        public IEnumerable<Students> Students { get; set; }
        public IEnumerable<Tasks> Tasks { get; set; }
        public IEnumerable<Status> Status { get; set; }

    }
}