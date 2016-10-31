namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StudentsID = c.Int(nullable: false),
                        TasksID = c.Int(nullable: false),
                        status = c.String(),
                        dateAdded = c.DateTime(nullable: false),
                        dateSubmitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID)
                .ForeignKey("dbo.Students", t => t.StudentsID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TasksID, cascadeDelete: true)
                .Index(t => t.StudentsID)
                .Index(t => t.TasksID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentsID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentsID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TasksID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        dateCreated = c.DateTime(nullable: false),
                        deadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TasksID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "TasksID", "dbo.Tasks");
            DropForeignKey("dbo.Status", "StudentsID", "dbo.Students");
            DropIndex("dbo.Status", new[] { "TasksID" });
            DropIndex("dbo.Status", new[] { "StudentsID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Students");
            DropTable("dbo.Status");
        }
    }
}
