using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using student_department.BLL;
using student_department.Models;

namespace student_department.Controllers
{
    public class StudentController : Controller
    {
        IStudent db;
        public StudentController(IStudent _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var std = db.GetAll();
            return View(std);
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                db.Add(std);
                return RedirectToAction("Index");
            }
           // ViewBag.Dept = new SelectList(db.GetDept(), "Id", "Name");
            return View(std);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dept = new SelectList(db.GetDept(), "Id", "Name");
            return View();
        }
        public IActionResult show(int? id)
        {
            var std = db.GetById(id.Value);

            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            var std = db.GetById(s.Id);
            std.Name = s.Name;
            std.Email = s.Email;
            std.Age = s.Age;
            std.DeptId = s.DeptId;
            std.Password = s.Password;
            std.CPassword = s.CPassword;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            db.Update(std);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var std = db.GetById(id.Value);
            if (std == null)
                return NotFound();
            ViewBag.Dept = new SelectList(db.GetDept(), "Id", "Name");
            return View(std);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            db.Delete(id.Value);
            return RedirectToAction("Index");
        }
        public JsonResult checkEmail(string email, int id = 0)
        {
            return Json(!db.IsEmailExist(email, id));
        }
    }
}
