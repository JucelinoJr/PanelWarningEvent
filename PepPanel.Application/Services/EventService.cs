using AutoMapper;
using PepPanel.Application.DTOs;
using PepPanel.Application.Interfaces;
using PepPanel.Domain.Entities;
using PepPanel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task Add(EventDTO eventDTO)
        {
            eventDTO.Id = GetNextSequenceValueAsync();
            var eventEntity = _mapper.Map<Event>(eventDTO);
            await _eventRepository.CreateAsync(eventEntity);
        }

        public async Task Delete(string? id)
        {
            var eventEntity = _eventRepository.GetByIdAsync(id).Result;
            await _eventRepository.DeleteAsync(eventEntity);
        }

        public async Task<EventDTO> GetEventById(string id)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(id);
            return _mapper.Map<EventDTO>(eventEntity);
        }
    
        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            var eventsEntity = await _eventRepository.GetEventsAsync();
            return _mapper.Map<IEnumerable<EventDTO>>(eventsEntity);
        }

        public async Task Update(EventDTO eventDTO)
        {
            var eventEntity = _mapper.Map<Event>(eventDTO);
            await _eventRepository.UpdateAsync(eventEntity);
        }

        public string GetNextSequenceValueAsync()
        {
            return _eventRepository.GetNextSequenceValueAsync();
        }
    }
}
