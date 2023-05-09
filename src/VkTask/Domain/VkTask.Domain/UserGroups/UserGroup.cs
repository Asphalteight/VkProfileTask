using VkTask.Domain.Users;

namespace VkTask.Domain.UserGroups;

/// <summary>
/// Модель групп пользователей.
/// </summary>
public class UserGroup
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название группы.
    /// </summary>
    public string Code { get; set; } = null!;
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;
    
    /// <summary>
    /// Список пользователей.
    /// </summary>
    public virtual List<User>? UsersList { get; set; }
}