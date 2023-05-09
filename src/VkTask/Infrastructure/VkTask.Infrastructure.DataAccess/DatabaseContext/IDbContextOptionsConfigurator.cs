using Microsoft.EntityFrameworkCore;

namespace VkTask.Infrastructure.DataAccess.DatabaseContext;

/// <summary>
/// Конфигуратор контекста.
/// </summary>
/// <typeparam name="TContext"></typeparam>
public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
{
    /// <summary>
    /// Сконфигурировать контекст базы данных.
    /// </summary>
    /// <param name="options">Опции.</param>
    void Configure(DbContextOptionsBuilder<TContext> options);
}