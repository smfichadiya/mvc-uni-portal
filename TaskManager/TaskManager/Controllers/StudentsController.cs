using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class StudentsController : Controller
    {
        private TaskManagerContext db = new TaskManagerContext();
        

    public object[] StudentsID { get; private set; }

        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //    //return View();
        //}
        //[HttpPost]
        //public ActionResult Index(string memberName)
        //{
        //    return Content("hello" + memberName);
        //}
        // example view

        // MyTaks
        public ActionResult Index()
        {
            IndexVM ivm = new IndexVM();
            ivm.Tasks = db.Tasks.ToList();
            //ivm.Student 
            return View(ivm);
        }

        [HttpGet]
        public ActionResult  MarkDone(int? statusID, int? studentId)
        {
            Status status;
            using (var db = new TaskManagerContext())
            {
                status = db.Status.Where(s => s.StatusID == statusID).FirstOrDefault<Status>(); ;
                if (status != null)
                {
                    status.status = "completed";
                    status.dateSubmitted = DateTime.Now;
                }
            }
            using (var db = new TaskManagerContext())
            {
                //Mark entity as modified
                db.Entry(status).State = System.Data.Entity.EntityState.Modified;
                //call SaveChanges
                db.SaveChanges();
                Students student = db.Students.Find(studentId);
                return RedirectToAction("MyTasks", student);
            }
        }

        [HttpGet]
        public ActionResult MarkHelp(int? statusID, int? studentId)
        {
       
            Status status;
            using (var db = new TaskManagerContext())
            {
                status = db.Status.Where(s => s.StatusID == statusID).FirstOrDefault<Status>(); ;
                if (status != null)
                {
                    status.status = "in need of help";
                }
            }
            using (var db = new TaskManagerContext())
            {
                //Mark entity as modified
                db.Entry(status).State = System.Data.Entity.EntityState.Modified;
                //call SaveChanges
                db.SaveChanges();
                Students student = db.Students.Find(studentId);
                return RedirectToAction("MyTasks", student);

            }
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string first_name, string last_name)
        {
            //find name in the db
            var student = db.Students
                           .Where(s => s.name == first_name && s.lastName == last_name)
                           .FirstOrDefault();
            return RedirectToAction("MyTasks", student);
        }
        [HttpPost] 
        public ActionResult Index(string memberName, string last_name, string[] selectedTask)
        {
            //find name in the db
            var student = db.Students
                           .Where(s => s.name == memberName && s.lastName == last_name)
                           .FirstOrDefault();


            if (student != null && selectedTask != null) {

                foreach (string checkedTask in selectedTask) //loop through the checked tasks
                {
                    var taskId = Int32.Parse(checkedTask); 
                    //selectedTask returns the values of checkboxes -id
                    //add a new task in the status table
                    db.Status.Add(new Status { TasksID = taskId, StudentsID = student.StudentsID, status = "active", dateSubmitted = DateTime.Now, dateAdded = DateTime.Now });
                    db.SaveChanges();
                }
                return RedirectToAction("MyTasks", student);
            }
            else
            {
                return RedirectToAction("Index");
            }

            //db.Students.FirstOrDefault(i => i.StudentsID == 1)

        }

        // display tasks only relative to the selected student
        public ActionResult MyTasks(Students student)
        {
            //find the tasks relative to the student

            MyTasksVM ivm = new MyTasksVM();
            ivm.Tasks = db.Tasks.ToList();
            ivm.Status = db.Status.ToList();
            ivm.Students = student;
            return View("MyTasksView", ivm);
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }
        public ActionResult Chat()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Help(int? taskID, int? studentID)
        {
            //var s = (from x in db.Status
            //         where x.TasksID == taskID && x.StudentsID == studentID
            //         select x).ToList();
            var status = db.Status
                        .Where(s => s.TasksID == taskID && s.StudentsID == studentID)
                        .ToList();
            status.ForEach(l => l.status = l.status.Replace("active", "waiting for help"));
            db.SaveChanges();
  
            return View();
        }
        public ActionResult Help()
        {
            return View(db.Tasks.ToList());
        }
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentsID,name,lastName")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentsID,name,lastName")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
