using PepPanel.Application.DTOs;
using PepPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.Interfaces
{
    public interface IWarningService
    {
        Task<IEnumerable<WarningDTO>> GetWarnings();
        Task<WarningDTO> GetWarningById(int? id);
        Task Add(WarningDTO warningDTO);
        Task Update(WarningDTO warningDTO);
        Task Delete(int? id);
        Task<int> GetNextSequenceValueAsync();
    }
}
