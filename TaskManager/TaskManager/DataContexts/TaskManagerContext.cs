using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskManagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TaskManagerContext() : base("name=TaskManagerContext")
        {
            
        }

        public System.Data.Entity.DbSet<TaskManager.Models.Students> Students { get; set; }
        public System.Data.Entity.DbSet<TaskManager.Models.Tasks> Tasks { get; set; }
        public System.Data.Entity.DbSet<TaskManager.Models.Status> Status { get; set; }


    }
}
