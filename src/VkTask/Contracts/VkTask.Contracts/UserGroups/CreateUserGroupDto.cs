namespace VkTask.Contracts.UserGroups;

/// <summary>
/// Модель создания группы.
/// </summary>
public class CreateUserGroupDto
{
    /// <summary>
    /// Название группы.
    /// </summary>
    public string Code { get; set; } = null!;
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;
}