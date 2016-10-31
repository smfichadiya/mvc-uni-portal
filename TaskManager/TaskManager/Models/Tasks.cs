using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Tasks
    {
        [Key]
        public int TasksID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime deadline { get; set; }
        public virtual ICollection<Status> Status { get; set; }

        public Tasks()
        {
            this.dateCreated = DateTime.Now;
        }
    }
}