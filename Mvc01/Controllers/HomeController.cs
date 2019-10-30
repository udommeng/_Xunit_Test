using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using App01;
using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;
using Mvc01.Services;

namespace Mvc01.Controllers {
    public class HomeController : Controller {

        private readonly ICounter counter;
        private readonly Robot rb;
        private readonly IPriceFeeder feeder;

        public HomeController(ICounter counter, Robot rb, IPriceFeeder feeder) {
            this.rb = rb;
            this.feeder = feeder;
            this.counter = counter;
        }

        public async Task<IActionResult> Index([FromServices] ICounter counter) {
            counter.Inc();
            ViewBag.Count = counter.Count;

            ViewBag.Orders = feeder.GetCurrentPrice().Last;
            //ViewBag.Orders = await rb.RunSimulation();
            //await rb.RunSimulation();
            //ViewBag.MinPrice = rb.MinPrice;

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
