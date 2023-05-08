namespace Task.Domain.Users;

/// <summary>
/// Модель стутусов пользователей.
/// </summary>
public class UserState
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
    
    /// <summary>
    /// Список пользователей.
    /// </summary>
    public virtual List<User>? UsersList { get; set; }
}