namespace VkTask.Contracts.UserGroups;

/// <summary>
/// Модель обновления группы.
/// </summary>
public class UpdateUserGroupDto
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