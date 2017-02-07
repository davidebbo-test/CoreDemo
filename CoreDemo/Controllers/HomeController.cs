using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace CoreDemo.Controllers
{
    public class MyConfig
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> _config;
        private readonly ILogger _logger;

        public HomeController(IOptions<MyConfig> config, ILoggerFactory loggerFactory)
        {
            _config = config;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Some information log");
            _logger.LogWarning("This is a warning");
            _logger.LogError("This is an error");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"Your application description page. {_config.Value.ApplicationName}!!";
            var telemetry = new TelemetryClient();
            telemetry.TrackEvent("Hello");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            throw new Exception("zzz");
            //return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
