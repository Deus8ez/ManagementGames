using FrontEnd.Models;
using ManagementGamesDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Test t = new Test
            {
                Id = 1,
                Name = "Test"
            };
            return View(t);
        }
    }
}
