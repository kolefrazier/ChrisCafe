using Microsoft.AspNetCore.Mvc;
using ChrisCafe.Models.ViewModels;
using ChrisCafe.Data.Caches;
using ChrisCafe.Providers;

namespace ChrisCafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public HomeController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public IActionResult Index()
        {
            SetCurrentPage("Home");
            Notice CurrentNotice = Cache.Notices.GetNotice(_dateTimeProvider);
            return View(CurrentNotice);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return RedirectToAction("Index", "Home");
        }
        private void SetCurrentPage(string state)
        {
            ViewData["CurrentPage"] = state;
        }
    }
}
