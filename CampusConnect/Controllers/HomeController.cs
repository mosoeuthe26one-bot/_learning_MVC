using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models;

namespace CampusConnect.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        int hour = DateTime.Now.Hour;

        ViewBag.Greeting = "I understand MVC";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
