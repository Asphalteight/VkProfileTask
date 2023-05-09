using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace VkTask.Infrastructure.DataAccess.DatabaseContext;

/// <summary>
/// Контекст БД
/// </summary>
public class VkTaskDbContext : DbContext
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="VkTaskDbContext"/>
    /// </summary>
    /// <param name="options"></param>
    public VkTaskDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => 
            t.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
} 