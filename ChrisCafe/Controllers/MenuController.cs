using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;
using ChrisCafe.Data.Caches;

namespace ChrisCafe.Controllers
{
    public class MenuController : Controller
    {
        public MenuController()
        {
        }

        public IActionResult Index(string display)
        {
            SetCurrentPage("Menu");
            FullMenu MenuResponse = Cache.Menu.CachedFullMenu;

            switch (display)
            {
                case ("Breakfast"):
                case ("breakfast"):
                    MenuResponse.ShowBreakfast = true;
                    MenuResponse.ShowLunch = false;
                    MenuResponse.ShowBeverages = true;
                    break;
                case ("Lunch"):
                case ("lunch"):
                    MenuResponse.ShowBreakfast = false;
                    MenuResponse.ShowLunch = true;
                    MenuResponse.ShowBeverages = true;
                    break;
                default:
                    MenuResponse.ShowBreakfast = true;
                    MenuResponse.ShowLunch = true;
                    MenuResponse.ShowBeverages = true;
                    break;
            }

            return View(MenuResponse);
        }

        public IActionResult Dinner()
        {
            return RedirectToAction("Index", "Home");
        }

        /* ----- Helper Methods ----- */
        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
    }
}