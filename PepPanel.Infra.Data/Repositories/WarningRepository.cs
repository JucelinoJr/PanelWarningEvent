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
        private readonly OracleConnectionFactory _oracleConnectionFactory;
        public WarningRepository(ApplicationDbContext context, OracleConnectionFactory oracleConnectionFactory)
        {
            _Warningcontext = context;
            _oracleConnectionFactory = oracleConnectionFactory;
        }

        public async Task<Warning> CreateAsync(Warning warning)
        {
            _Warningcontext.Add(warning);
            await _Warningcontext.SaveChangesAsync();
            return warning;
        }

        public async Task<Warning> DeleteAsync(Warning warning)
        {
            _Warningcontext.Remove(warning);
            await _Warningcontext.SaveChangesAsync();
            return warning;
        }

        public async Task<Warning> GetByIdAsync(int? id)
        {
            return await _Warningcontext.Warning.FindAsync(id);
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

        public async Task<int> GetNextSequenceValueAsync()
        {
            using (var connection = (OracleConnection)_oracleConnectionFactory.CreateConnection())
            {
                await connection.OpenAsync();  // Usando o método assíncrono de abertura de conexão

                // Cria e executa o comando SQL para obter o próximo valor da sequência
                using (var command = new OracleCommand("SELECT aplicacoes.seq_warning.NEXTVAL FROM dual", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader.GetInt32(0);  // Obtém o valor da sequência
                        }
                    }
                }
            }

            throw new InvalidOperationException("Não foi possível obter o próximo valor da sequência.");
        }

    }
}
