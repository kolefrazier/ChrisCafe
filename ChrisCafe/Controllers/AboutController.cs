using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            SetCurrentPage("About");
            return View();
        }

        public IActionResult Contact()
        {
            SetCurrentPage("ContactLocate");
            return View();
        }

        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
    }
}