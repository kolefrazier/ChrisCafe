using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

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