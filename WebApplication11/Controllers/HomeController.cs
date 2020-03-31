using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication11.Models;
using STISSOEntryCore4;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication11.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly STISSOEntryController sTISSOEntry;
        private readonly HttpContext httpContext;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, STISSOEntryController sTISSOEntry,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _config = config;
            this.sTISSOEntry = sTISSOEntry;
            this.httpContext = httpContextAccessor.HttpContext;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //STISSOEntryController sTISSOEntry = new STISSOEntryController(HttpContext, _config);
            return sTISSOEntry.LogInAsync("").Result;
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
