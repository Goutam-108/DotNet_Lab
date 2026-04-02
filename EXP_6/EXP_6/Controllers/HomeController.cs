using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EXP_6.Models;

namespace EXP_6.Controllers;

public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET Core MVC!";
            return View();
        }
    }
