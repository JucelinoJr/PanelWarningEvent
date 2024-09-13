using Microsoft.AspNetCore.Mvc;
using PepPanel.Application.DTOs;
using PepPanel.Application.Interfaces;
using PepPanel.Application.Services;

namespace PepPanelMvc.WebUI.Controllers
{
    public class WarningController : Controller
    {
        private readonly IWarningService _warningService;
        public WarningController(IWarningService warningService) 
        {
            _warningService = warningService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var warnings = await _warningService.GetWarnings();
            return View(warnings);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarningDTO warning)
        {
            if (ModelState.IsValid) 
            {
                await _warningService.Add(warning);
                return RedirectToAction(nameof(Index));
            }
            return View(warning);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var WarningDto = await _warningService.GetWarningById(id);

            if (WarningDto == null) return NotFound();
            return View(WarningDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WarningDTO warning)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _warningService.Update(warning);
                }
                catch (Exception ex) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(warning);
        }
    }
}
