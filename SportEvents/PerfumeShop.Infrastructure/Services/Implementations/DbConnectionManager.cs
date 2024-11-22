﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using PerfumeShop.Infrastructure.Services.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Infrastructure.Services.Implementations;

public class DbConnectionManager : IDbConnectionManager
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<DbConnectionManager> _logger;

    private string NpgsqlConnectionString => _configuration["ConnectionStrings:DbConnection"];
    public DbConnectionManager(IConfiguration configuration, ILogger<DbConnectionManager> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    private NpgsqlConnection PostgresDbConnection => new(NpgsqlConnectionString);

    public QueryFactory PostgresQueryFactory => new(PostgresDbConnection, new PostgresCompiler(), 60)
    {
        Logger = compiled => { _logger.LogInformation("Query = {@Query}", compiled.ToString()); }
    };
}