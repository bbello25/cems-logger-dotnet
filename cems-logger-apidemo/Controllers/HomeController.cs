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
        private readonly SecondLevel _secondLevel;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _secondLevel = new SecondLevel();
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("error1")]
        public IActionResult ThrowError1()
        {

            try
            {
                _secondLevel.ThrowE1();
            }
            catch (Exception e)
            {
             
                _logger.LogError(e, "Test exception");
            }

            return View("Index");
        }

        [HttpGet("error2")]
        public IActionResult ThrowError2()
        {

            try
            {
                _secondLevel.ThrowE2();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Test exception");
            }

            return View("Index");
        }


        [HttpGet("error3")]
        public IActionResult ThrowError3()
        {

            try
            {
                _secondLevel.ThrowE3();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Test exception");
            }

            return View("Index");
        }

        [HttpGet("errorCommon")]
        public IActionResult ThrowErrorCommon()
        {

            try
            {
                _secondLevel.ThrowECommon("ThrowECommon");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Test exception");
            }

            return View("Index");
        }



        [HttpGet("errorElse")]
        public IActionResult ThrowSthElse()
        {

            try
            {
                _secondLevel.ThrowStElse();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Test exception");
            }

            return View("Index");
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
