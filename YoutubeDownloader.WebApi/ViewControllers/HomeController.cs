using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeDownloader.WebApi.Models;

namespace YoutubeDownloader.WebApi.Controllers
{
    [Route("/")]
    [Route("/home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Layouts/Home/Home.cshtml");
        }
        
    }
}