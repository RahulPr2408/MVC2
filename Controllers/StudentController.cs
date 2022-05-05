using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MVC_2.Models;
using MVC_2.Data;


namespace MVC_2.Controllers {
    public class StudentController : Controller {

        private readonly ApplicationDbContext db;
        public StudentController(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<IActionResult> Index(string SearchString) {

            var studentList = from t in db.students select t;

            if(!String.IsNullOrEmpty(SearchString)) {
                studentList = studentList.Where(s => s.student_Name!.Contains(SearchString));
            }
            return View(await studentList.ToListAsync());
        }

        [HttpGet]
        public IActionResult Edit(int studentid) {

            Student? s = db.students!.Find(studentid);

            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Student s){

            db.students!.Update(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int studentid) {

            var s = db.students!.Find(studentid);

            db.students!.Remove(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("student_Name , student_age , student_Contact")]Student s){

            db.students!.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}