using DotNET6_MVC_CodingChallengeTemplate.Models;
using LoanSharkMVC.Logic;
using LoanSharkMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNET6_MVC_CodingChallengeTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult App()
        {
            LoanModel model = new();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(LoanModel model)
        {
            LoanModel output = LoanCalculator.GetValues(model);

            return View(output);
        }

        public IActionResult Code()
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