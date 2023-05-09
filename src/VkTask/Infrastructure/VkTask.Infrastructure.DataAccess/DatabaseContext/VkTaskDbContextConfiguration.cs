using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VkTask.Infrastructure.DataAccess.DatabaseContext;

/// <inheritdoc/>
public class VkTaskDbContextConfiguration : IDbContextOptionsConfigurator<VkTaskDbContext>
{ 
    private const string PostgresConnectionStringName = "PostgresVkTaskDb";
    
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;
    
    public VkTaskDbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    public void Configure(DbContextOptionsBuilder<VkTaskDbContext> options)
    {
        var connectionString = _configuration.GetConnectionString(PostgresConnectionStringName);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{PostgresConnectionStringName}'");
        }

        options.UseNpgsql(connectionString);
        options.UseLoggerFactory(_loggerFactory);
    }
}