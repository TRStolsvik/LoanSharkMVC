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
            LoanModel loan = new();

            loan.LoanPayment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.LoanInterest = 3.5m;
            loan.LoanAmount = 15000m;
            loan.LoanTerm = 60;

            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(LoanModel loan)
        {
            LoanModel output = LoanCalculator.GetPayments(loan);

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