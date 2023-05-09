namespace VkTask.Contracts.UserStates;

/// <summary>
/// Модель обновления статуса.
/// </summary>
public class UpdateUserStateDto
{
    /// <summary>
    /// Название статуса.
    /// </summary>
    public string Code { get; set; } = null!;
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;
}