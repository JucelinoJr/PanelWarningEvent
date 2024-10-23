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
    public class WarningService : IWarningService
    {
        private IWarningRepository _warningRepository;
        private readonly IMapper _mapper;

        public WarningService(IWarningRepository warningRepository, IMapper mapper)
        {
            _warningRepository = warningRepository;
            _mapper = mapper;
        }

        public async Task Add(WarningDTO warningDTO)
        {
            warningDTO.Id = GetNextSequenceValueAsync();
            var warningEntity = _mapper.Map<Warning>(warningDTO);
            await _warningRepository.CreateAsync(warningEntity);
        }

        public async Task Delete(string? id)
        {
            var warningEntity = _warningRepository.GetWarningById(id).Result;
            await _warningRepository.DeleteAsync(warningEntity);
        }

        public async Task<WarningDTO> GetWarningById(string? id)
        {
            var warningEntity = await _warningRepository.GetWarningById(id);
            return _mapper.Map<WarningDTO>(warningEntity);
        }

        public async Task<IEnumerable<WarningDTO>> GetWarnings()
        {
            var warningsEntity = await _warningRepository.GetWarningsAsync();
            return _mapper.Map<IEnumerable<WarningDTO>>(warningsEntity);
        }

        public async Task Update(WarningDTO warningDTO)
        {
            var warningEntity = _mapper.Map<Warning>(warningDTO);
            await _warningRepository.UpdateAsync(warningEntity);
        }
        public string GetNextSequenceValueAsync()
        {
            return _warningRepository.GetNextSequenceValueAsync();
        }
    }
}
