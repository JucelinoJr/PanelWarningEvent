using Microsoft.AspNetCore.Mvc;
using PepPanel.Application.DTOs;
using PepPanel.Application.Interfaces;
using PepPanel.Application.Services;
using PepPanel.Domain.Entities;

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

        [HttpPost]
        public async Task<IActionResult> Create(EventDTO eventdto)
        {
            if (ModelState.IsValid)
            {
                await _eventService.Add(eventdto);
                return RedirectToAction(nameof(Index));
            }
            return View(eventdto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == "") return NotFound();
            var eventDto = await _eventService.GetEventById(id);

            if (eventDto == null) return NotFound();
            return View(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventDTO eventDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _eventService.Update(eventDTO);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "") return NotFound();
            var eventDTO = await _eventService.GetEventById(id);

            if (eventDTO == null) return NotFound();
            return View(eventDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EventDTO eventDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _eventService.Delete(eventDTO.Id);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventDTO);
        }
    }
        
}
