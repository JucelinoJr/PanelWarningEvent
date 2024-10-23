using PepPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Domain.Interfaces
{
    public interface IWarningRepository
    {
        Task<IEnumerable<Warning>> GetWarningsAsync();
        Task<Warning> GetWarningById(string? id);
        Task<Warning> CreateAsync(Warning warning);
        Task<Warning> UpdateAsync(Warning warning);
        Task<Warning> DeleteAsync(Warning warning);
        string GetNextSequenceValueAsync();

    }
}
