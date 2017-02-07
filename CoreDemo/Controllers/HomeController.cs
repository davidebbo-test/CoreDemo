using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;

namespace CoreDemo.Controllers
{
    public class MyConfig
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
    }
    public class HomeController : Controller
    {
        IOptions<MyConfig> _config;

        public HomeController(IOptions<MyConfig> config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
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
