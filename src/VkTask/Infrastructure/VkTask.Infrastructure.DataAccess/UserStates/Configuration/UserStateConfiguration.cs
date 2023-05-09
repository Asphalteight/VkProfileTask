using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VkTask.Domain.UserStates;

namespace VkTask.Infrastructure.DataAccess.UserStates.Configuration;

/// <summary>
/// Конфигурация сущности статуса.
/// </summary>
public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
{
    public void Configure(EntityTypeBuilder<UserState> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Code).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(200);
    }
}