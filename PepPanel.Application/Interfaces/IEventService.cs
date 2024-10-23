using PepPanel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();
        Task<EventDTO> GetEventById(string id);
        Task Add(EventDTO warningDTO);
        Task Update(EventDTO warningDTO);
        Task Delete(string? id);
        string GetNextSequenceValueAsync();
    }
}
