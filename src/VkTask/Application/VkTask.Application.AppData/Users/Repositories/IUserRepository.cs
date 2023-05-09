using System.Linq.Expressions;
using VkTask.Contracts.Users;
using VkTask.Domain.Users;

namespace VkTask.Application.AppData.Users.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создание пользователя.
    /// </summary>
    /// <param name="model">Модель пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пользователя.</returns>
    Task<int> CreateAsync(User model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение пользователя.
    /// </summary>
    /// <param name="model">Модель пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном пользователе.</returns>
    Task<InfoUserDto> UpdateAsync(User model, CancellationToken cancellationToken);

    //Фактическое удаление из БД: 
    
    // /// <summary>
    // /// Удаление пользователя.
    // /// </summary>
    // /// <param name="id">Идентификатор удаляемого пользователя.</param>
    // /// <param name="cancellationToken">Токен отмены.</param>
    // /// <returns>Статус удаления.</returns>
    // Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пользователя.</returns>
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Поиск пользователя по фильтру.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellation"></param>
    /// <returns>Модель пользователя</returns>
    Task<User?> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken cancellation);
    
    /// <summary>
    /// Получение всех пользователей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех пользователей.</returns>
    Task<IEnumerable<InfoUserDto>> GetAllAsync(CancellationToken cancellationToken);
}