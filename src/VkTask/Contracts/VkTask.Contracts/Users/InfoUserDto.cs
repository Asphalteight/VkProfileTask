namespace VkTask.Contracts.Users;

/// <summary>
/// Модель информации о пользователе.
/// </summary>
public class InfoUserDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Идентификатор группы пользователя.
    /// </summary>
    public int UserGroupId { get; set; }

    /// <summary>
    /// Идентификатор статуса пользователя.
    /// </summary>
    public int UserStateId { get; set; }
}