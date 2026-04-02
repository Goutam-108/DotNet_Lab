using Microsoft.AspNetCore.Mvc;
using ValidationMVC.Models;

namespace ValidationMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Form Submit
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Form submitted successfully!";
                return View();
            }
            return View(student);
        }
    }
}