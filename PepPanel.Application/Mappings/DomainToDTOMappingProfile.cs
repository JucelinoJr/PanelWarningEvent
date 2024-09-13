using AutoMapper;
using PepPanel.Application.DTOs;
using PepPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Warning, WarningDTO>().ReverseMap();
        }
    }
}
