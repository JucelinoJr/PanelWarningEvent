using Microsoft.AspNetCore.Mvc;
using PepPanel.Application.Interfaces;

namespace PepPanelMvc.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
