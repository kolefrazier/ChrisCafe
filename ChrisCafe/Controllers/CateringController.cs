using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Data.Caches;

namespace ChrisCafe.Controllers
{
    public class CateringController : Controller
    {
        public IActionResult Index()
        {
            SetCurrentPage("Catering");
            return View(Cache.CateringMenu.Menu);
        }

        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
    }
}