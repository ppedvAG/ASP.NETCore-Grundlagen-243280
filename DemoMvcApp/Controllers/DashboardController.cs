﻿using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            string userName = User.Identity.Name;

            // Dieses Model ist spezifisch nur fuer die Darstellung, also die View verantwortlich. Deshalb auch ViewModel.
            // Normalerweise koennten wir auch einen Mapper aufrufen, welcher ein DbModel oder LogikModel zu einem ViewModel transformiert und umgekehrt.
            var model = new DashboardViewModel
            {
                UserName = userName
            };
            return View(model);
        }
    }
}
