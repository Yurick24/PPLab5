using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PPLab6.Models;
using System;
using System.Diagnostics;
using System.Text;

namespace PPLab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int number)
        {
            if (number % 7 == 0)
            {
                ViewBag.Result = $"Число {number} кратно 7-ми.";
            }
            else
            {
                ViewBag.Result = $"Число {number} не кратно 7-ми.";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Block2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Block2(string input)
        {
            string str = input;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'с' || str[i] == 'С')
                {
                    str = str.Remove(i, 1);
                }
                if (i == str.Length - 1)
                {
                    str = str.Remove(i, 1);
                    str += "_";
                }
            }
            ViewBag.H = str;
            return View();
        }
        public IActionResult Block3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Block3(string txt)
        {
            string str = txt;
            int[] mass = new int[10];
            int sumSquare = 0;
            int sumCube = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                {
                    str = str.Remove(i, 1);
                }
                mass[i] = int.Parse(str[i].ToString());
                if (i % 2 == 0)
                {
                    sumSquare += mass[i] * mass[i];
                    sumCube += mass[i] * mass[i] * mass[i];
                }
            }
            ViewBag.Square = sumSquare;
            ViewBag.Cube = sumCube;
            return View();
        }
    }
}