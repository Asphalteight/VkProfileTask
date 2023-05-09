using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VkTask.Domain.UserGroups;

namespace VkTask.Infrastructure.DataAccess.UserGroups.Configuration;

/// <summary>
/// Конфигурация сущности группы.
/// </summary>
public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Code).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(200);
    }
}