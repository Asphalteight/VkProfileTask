namespace VkTask.Contracts.UserStates;

/// <summary>
/// Модель создания статуса.
/// </summary>
public class CreateUserStateDto
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