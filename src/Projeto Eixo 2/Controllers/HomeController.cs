﻿using Microsoft.AspNetCore.Mvc;
using Projeto_Eixo_2.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Projeto_Eixo_2.Controllers
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                return RedirectToAction("Details", "Cobradores", new {id = userId});
            }
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Services()
        {
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
    }
}