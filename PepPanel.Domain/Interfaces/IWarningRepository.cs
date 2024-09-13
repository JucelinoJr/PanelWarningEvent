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
        Task<Warning> GetByIdAsync(int? id);
        Task<Warning> CreateAsync(Warning warning);
        Task<Warning> UpdateAsync(Warning warning);
        Task<Warning> DeleteAsync(Warning warning);
        Task<int> GetNextSequenceValueAsync();

    }
}
