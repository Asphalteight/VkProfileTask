using VkTask.Contracts.Users;

namespace VkTask.Application.AppData.Users.Services;

/// <summary>
/// Сервис для работы с пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создание пользователя.
    /// </summary>
    /// <param name="model">Модель пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пользователя.</returns>
    Task<int> CreateUserAsync(CreateUserDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение пользователя.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном пользователе.</returns>
    Task<InfoUserDto?> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о пользователе.</returns>
    Task<InfoUserDto?> GetUserByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех пользователей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список пользователей.</returns>
    Task<IEnumerable<InfoUserDto>> GetAllUsers(CancellationToken cancellationToken);
}