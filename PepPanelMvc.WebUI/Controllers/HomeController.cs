using Microsoft.AspNetCore.Mvc;
using PepPanel.Application.Interfaces;
using PepPanelMvc.WebUI.Models;
using System.Diagnostics;

namespace PepPanelMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWarningService _warningService;
        private readonly IEventService _eventService;

        public HomeController(ILogger<HomeController> logger, IWarningService warningService, IEventService eventService)
        {
            _warningService = warningService;
            _logger = logger;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var warnings = await _warningService.GetWarnings();
            var events = await _eventService.GetEvents();
            var homeViewModel = new HomeViewModel
            {
                eventDTO = events,
                warningDTO = warnings
            };
            return View(homeViewModel);
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
