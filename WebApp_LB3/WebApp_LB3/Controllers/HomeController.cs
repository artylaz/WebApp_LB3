using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_LB3.Models;

namespace WebApp_LB3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(DataViewModel dateViewModel)
        {
            if (dateViewModel.IsRes)
            {
                dateViewModel = new DataViewModel
                {
                    A1_PloPovZag = 50,
                    A1_ColvoZag_1 = 1,
                    A1_ColvoZag_2 = 1,
                    A1_ColvoZag_3 = 1,
                    A1_ColvoZag_4 = 0,
                    A1_ColvoZag_5 = 0,
                    A1_ColvoZag_6 = 1,
                    A1_ColvoNaOd = 4,

                    A2_PloPovZag = 46,
                    A2_ColvoZag_1 = 0,
                    A2_ColvoZag_2 = 1,
                    A2_ColvoZag_3 = 0,
                    A2_ColvoZag_4 = 1,
                    A2_ColvoZag_5 = 1,
                    A2_ColvoZag_6 = 0,
                    A2_ColvoNaOd = 1,

                    A3_PloPovZag = 31,
                    A3_ColvoZag_1 = 0,
                    A3_ColvoZag_2 = 0,
                    A3_ColvoZag_3 = 1,
                    A3_ColvoZag_4 = 0,
                    A3_ColvoZag_5 = 1,
                    A3_ColvoZag_6 = 2,
                    A3_ColvoNaOd = 2,

                    A4_PloPovZag = 28,
                    A4_ColvoZag_1 = 1,
                    A4_ColvoZag_2 = 0,
                    A4_ColvoZag_3 = 0,
                    A4_ColvoZag_4 = 0,
                    A4_ColvoZag_5 = 0,
                    A4_ColvoZag_6 = 0,
                    A4_ColvoNaOd = 3,

                    A5_PloPovZag = 46,
                    A5_ColvoZag_1 = 1,
                    A5_ColvoZag_2 = 1,
                    A5_ColvoZag_3 = 1,
                    A5_ColvoZag_4 = 1,
                    A5_ColvoZag_5 = 1,
                    A5_ColvoZag_6 = 0,
                    A5_ColvoNaOd = 4,

                    Zag_F = 180,
                    Zag_R = 150,
                };
                return View(dateViewModel);
            }
            else
            {
                ViewBag.Res = "Решение не найдено";
                return View(dateViewModel);
            }
        }
        [HttpGet]
        public IActionResult Result(DataViewModel dateViewModel)
        {
            var resultViewModel = new ResultViewModel(dateViewModel);
            var isRes = resultViewModel.SolverRun();
            if (isRes == true)
                return View(resultViewModel);
            else
            {
                return RedirectToAction("Index", dateViewModel);
            }

        }
        [HttpGet]
        public IActionResult Report(DataViewModel dateViewModel)
        {
            var resultViewModel = new ResultViewModel(dateViewModel);
            var isRes = resultViewModel.SolverRun();
            return View(resultViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}