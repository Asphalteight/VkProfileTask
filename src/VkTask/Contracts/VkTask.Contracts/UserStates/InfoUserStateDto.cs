namespace VkTask.Contracts.UserStates;

/// <summary>
/// Модель информации о статусе.
/// </summary>
public class InfoUserStateDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название статуса.
    /// </summary>
    public string Code { get; set; } = null!;
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;
}