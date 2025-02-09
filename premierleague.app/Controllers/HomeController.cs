using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using premierleague.app.Models;
using premierleague.service.IService;
using premierleague.service.Service;
using Newtonsoft.Json;
using premierleague.core.Entities;

namespace premierleague.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;

        public HomeController(ILogger<HomeController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
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

        public async Task<IActionResult> GetAllData()
        {
            return View(await _dataService.GetAllData());
        }
        public async Task<IActionResult> GetGoalsBySeason()
        {
            var result = await _dataService.GetGoalsBySeason();
            result.Sort((a,b) => a.season.CompareTo(b.season));
            return PartialView("GetGoalsBySeason", result);
        }
    }
}
