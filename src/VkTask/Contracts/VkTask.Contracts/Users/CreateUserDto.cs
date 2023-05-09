namespace VkTask.Contracts.Users;

/// <summary>
/// Модель создания пользователя.
/// </summary>
public class CreateUserDto
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
}