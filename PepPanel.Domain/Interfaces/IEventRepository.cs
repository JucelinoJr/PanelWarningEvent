using PepPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventById(string? id);
        Task<Event> CreateAsync(Event Event);
        Task<Event> UpdateAsync(Event Event);
        Task<Event> DeleteAsync(Event Event);
        string GetNextSequenceValueAsync();
    }
}
