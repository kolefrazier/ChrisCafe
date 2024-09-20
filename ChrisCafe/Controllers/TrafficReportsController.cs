using ChrisCafe.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ChrisCafe.Controllers
{
    //public class TrafficReportsController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        // Basically a debug check.
    //        // * Windows = local dev environment, use sample files.
    //        // * Linux = prod environment, use goaccess output directory.
    //        string path = (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    //            ? @"C:\Users\k-fra\Documents\Git\ChrisCafe\ChrisCafe\RawData\Reports"
    //            : @"/var/www/ga.chriscafe.net/";

    //        string[] rawFiles = Directory.GetFiles(path);
    //        string[] files = Array
    //            .ConvertAll(rawFiles, f => f.Replace(path, "").Replace("\\", ""))
    //            .OrderByDescending(f => f)
    //            .ToArray();

    //        var reports = new ReportsListing()
    //        {
    //            Files = files
    //        };

    //        SetCurrentPage("Reports");
    //        return View(reports);
    //    }

    //    private void SetCurrentPage(string state)
    //    {
    //        ViewData["CurrentPage"] = state;
    //    }
    //}
}