using Microsoft.AspNetCore.Mvc;
using student_department.BLL;
using student_department.Models;

namespace student_department.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL departmentBLL = new DepartmentBLL();
        public IActionResult Index(int id)
        {
            var Dept = departmentBLL.GetAll();
            return View(Dept);
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            departmentBLL.Add(dept);
            return RedirectToAction("Index");
            //return Content($"Student {std.Name} is added successfully");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult show()
        {
            DBMVCContext dBMVCContext = new DBMVCContext();
            var Dept = dBMVCContext.Departments.FirstOrDefault(s => s.Id == 1);

            return View(Dept);
        }
        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            departmentBLL.Update(dept);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var dept = departmentBLL.GetByID(id.Value);
            if (dept == null)
                return NotFound();
            return View(dept);
        }
        public IActionResult Delete(int? id)
        {
            departmentBLL.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
