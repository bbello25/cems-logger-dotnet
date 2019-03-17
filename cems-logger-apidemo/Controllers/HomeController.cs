using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cems_logger_apidemo.logging;
using Microsoft.AspNetCore.Mvc;
using cems_logger_apidemo.Models;
using Microsoft.Extensions.Logging;

namespace cems_logger_apidemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            try
            {
                throw new Exception("Test exception");

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Test exception");
            }


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
}
