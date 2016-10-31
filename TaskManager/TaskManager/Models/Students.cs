using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Students
    {
        [Key]
        public int StudentsID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public virtual ICollection<Status> Status { get; set; }
    }
}