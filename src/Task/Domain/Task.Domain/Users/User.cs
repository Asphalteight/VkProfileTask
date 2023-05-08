namespace Task.Domain.Users;

/// <summary>
/// Модель пользователя.
/// </summary>
public class User
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
    /// Группа пользователя.
    /// </summary>
    public virtual UserGroup UserGroup { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор статуса пользователя.
    /// </summary>
    public int UserStateId { get; set; }
    
    /// <summary>
    /// Статус пользователя.
    /// </summary>
    public virtual UserState UserState { get; set; } = null!;
}