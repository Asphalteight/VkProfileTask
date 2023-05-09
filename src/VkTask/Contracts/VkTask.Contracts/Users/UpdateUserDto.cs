namespace VkTask.Contracts.Users;

/// <summary>
/// Модель для обновления пользователя.
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор группы пользователя.
    /// </summary>
    public int UserGroupId { get; set; }

    /// <summary>
    /// Идентификатор статуса пользователя.
    /// </summary>
    public int UserStateId { get; set; }
}