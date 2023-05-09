using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VkTask.Domain.Users;

namespace VkTask.Infrastructure.DataAccess.Users.Configuration;

/// <summary>
/// Конфигурация сущности пользователя.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Login).HasMaxLength(50);
        builder.Property(p => p.Password).HasMaxLength(50);
        builder.Property(p => p.CreatedDate).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));
    }
}