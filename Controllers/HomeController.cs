using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_schnaider.Models;

namespace TP06_schnaider.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
