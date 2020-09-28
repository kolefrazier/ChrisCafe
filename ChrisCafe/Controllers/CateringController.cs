using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Data;

namespace ChrisCafe.Controllers
{
    public class CateringController : Controller
    {
        public IActionResult Index()
        {
            SetCurrentPage("Catering");
            return View(Cache.CateringMenu.Menu);
        }

        #region Helper Methods
        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
        #endregion 
    }
}