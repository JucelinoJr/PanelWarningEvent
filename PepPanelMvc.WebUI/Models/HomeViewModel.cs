using PepPanel.Application.DTOs;

namespace PepPanelMvc.WebUI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<EventDTO> eventDTO {  get; set; }
        public IEnumerable<WarningDTO> warningDTO { get; set; }
    }
}
