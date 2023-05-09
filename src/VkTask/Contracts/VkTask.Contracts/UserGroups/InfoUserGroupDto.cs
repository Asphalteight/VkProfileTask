namespace VkTask.Contracts.UserGroups;

/// <summary>
/// Модель информации о группе.
/// </summary>
public class InfoUserGroupDto
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
}