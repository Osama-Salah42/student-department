using Microsoft.AspNetCore.Mvc;
namespace student_department.Controllers
{
    public class CourseController:Controller
    {
        public IActionResult Details()
        {
            /*//cookies
            Response.Cookies.Append("id", "3");
            Response.Cookies.Append("name", "hassan");*/
            //session
            HttpContext.Session.SetInt32("id", 5);
            HttpContext.Session.SetString("name", "Osama");
            ViewBag.Id = 3;
            ViewBag.name = "Osama";
            return View();
        }
        public IActionResult Display()
        {
            /*int id = Convert.ToInt32(Request.Cookies["id"]);
            string name = Request.Cookies["name"];*/
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            string name = HttpContext.Session.GetString("name");
            ViewBag.id = id;
            ViewBag.name = name;
            return View();
        }
    }
}

