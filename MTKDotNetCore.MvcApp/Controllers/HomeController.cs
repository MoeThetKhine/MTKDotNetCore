﻿using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MvcApp.Models;
using System.Diagnostics;

namespace MTKDotNetCore.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Index

        public IActionResult Index()
        {
            ViewBag.Message = "Hello from Viewbag";
            ViewData["Message2"] = "Hello from ViewData";

            HomeResponseModel model = new HomeResponseModel();
            model.AlertMessage = "Hello from Model";

            //return Redirect("/Home/Privacy");

            return View(model);
        }

        #endregion

        #region Privacy

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
