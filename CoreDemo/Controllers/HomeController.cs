using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;

namespace CoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
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
