﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestQuest.Presentation.Models;
using TestQuest.DataAccess;

namespace TestQuest.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("index")]
    public DbTest Index(DbTest test)
    {
        return test;
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
