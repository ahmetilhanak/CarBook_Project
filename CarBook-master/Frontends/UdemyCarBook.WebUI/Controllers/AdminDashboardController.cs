﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
