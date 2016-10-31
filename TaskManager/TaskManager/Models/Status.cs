using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public  int StudentsID { get; set; }

        [ForeignKey("StudentsID")]
        public virtual Students Students { get; set; }

        public  int TasksID { get; set; }

        [ForeignKey("TasksID")]
        public virtual Tasks Tasks { get; set; }

        public string status { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime dateSubmitted { get; set; }


        public Status()
        {
            if(this.status == "completed")
            {
                dateSubmitted = DateTime.Now;
            }
            dateAdded = DateTime.Now;
        }
    }
}