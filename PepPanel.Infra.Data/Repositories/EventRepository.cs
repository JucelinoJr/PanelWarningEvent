using Microsoft.EntityFrameworkCore;
using PepPanel.Domain.Entities;
using PepPanel.Domain.Interfaces;
using PepPanel.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        ApplicationDbContext _EventContext;
        public EventRepository(ApplicationDbContext context) 
        { 
            _EventContext = context;
        }

        public async Task<Event> CreateAsync(Event Event)
        {
            _EventContext.Add(Event);
            await _EventContext.SaveChangesAsync();
            return Event;
        }

        public async Task<Event> DeleteAsync(Event Event)
        {
            _EventContext.Remove(Event);
            await _EventContext.SaveChangesAsync();
            return Event;
        }

        public async Task<Event> GetEventById(string? id)
        {
            var events = await _EventContext.Event.ToListAsync();
            foreach (var e in events)
            {
                if (e.Id == id)
                {
                    Event selectedEvent = e;
                    return selectedEvent;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _EventContext.Event.ToListAsync();
        }

        public async Task<Event> UpdateAsync(Event Event)
        {
            _EventContext.Update(Event);
            await _EventContext.SaveChangesAsync();
            return Event;
        }
        public string GetNextSequenceValueAsync()
        {
            return _EventContext.ContextId.InstanceId.ToString();
        }
    }
}
