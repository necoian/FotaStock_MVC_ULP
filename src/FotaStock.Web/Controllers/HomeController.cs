using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotaStock.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace FotaStock.Web.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }


}
