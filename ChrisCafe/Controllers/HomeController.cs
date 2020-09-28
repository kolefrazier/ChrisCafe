using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;
using ChrisCafe.Data.Providers;

namespace ChrisCafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public HomeController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        #region Views
        public IActionResult Index()
        {
            SetCurrentPage("Home");
            Notice CurrentNotice = ChrisCafe.Data.Cache.Notices.GetNotice(_dateTimeProvider);
            return View(CurrentNotice);
        }
        #endregion

        #region Partials
        #endregion

        #region Error Handlers
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Helper Methods
        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
        #endregion 
    }
}
