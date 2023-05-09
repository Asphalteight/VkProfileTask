namespace VkTask.Contracts.Users;

/// <summary>
/// Модель для авторизации пользователя.
/// </summary>
public class LoginUserDto
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
}