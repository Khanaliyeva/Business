using Business.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Business.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}