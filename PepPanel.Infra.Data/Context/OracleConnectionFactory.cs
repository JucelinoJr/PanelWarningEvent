using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

public class OracleConnectionFactory
{
    private readonly IConfiguration _configuration;

    public OracleConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        // Busca a connection string do appsettings.json
        string connectionString = _configuration.GetConnectionString("DbcauOracleConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'OracleDbConnection' not found.");
        }

        // Cria e retorna a conexão Oracle
        var connection = new OracleConnection(connectionString);
        return connection;
    }
}