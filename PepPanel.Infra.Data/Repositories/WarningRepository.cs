using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
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
    public class WarningRepository : IWarningRepository
    {
        ApplicationDbContext _Warningcontext;
        public WarningRepository(ApplicationDbContext context)
        {
            _Warningcontext = context;
        }

        public async Task<Warning> CreateAsync(Warning warning)
        {
            _Warningcontext.Add(warning);
            await _Warningcontext.SaveChangesAsync();
            return warning;
        }

        public async Task<Warning> DeleteAsync(Warning warning)
        {
            _Warningcontext.Warning.Remove(warning);
            await _Warningcontext.SaveChangesAsync();
            return warning;
        }

        public async Task<Warning> GetWarningById(string? id)
        {
            var warnings = await _Warningcontext.Warning.ToListAsync();
            foreach (var w in warnings)
            {
                if (w.Id == id)
                {
                    Warning selectedWarning = w;
                    return selectedWarning;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Warning>> GetWarningsAsync()
        {
            return await _Warningcontext.Warning.ToListAsync();
        }

        public async Task<Warning> UpdateAsync(Warning warning)
        {
            _Warningcontext.Update(warning);
            await _Warningcontext.SaveChangesAsync();
            return warning;
        }

        public string GetNextSequenceValueAsync()
        {
            return _Warningcontext.ContextId.InstanceId.ToString();
        }

    }
}
