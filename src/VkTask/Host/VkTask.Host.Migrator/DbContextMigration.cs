using Microsoft.EntityFrameworkCore;
using VkTask.Infrastructure.DataAccess.DatabaseContext;

namespace VkTask.Host.Migrator;

/// <summary>
/// Контекст базы данных для мигратора.
/// </summary>
public class DbContextMigration : VkTaskDbContext
{
    public DbContextMigration(DbContextOptions options) : base(options)
    {
    }
}