using VkTask.Contracts.UserStates;

namespace VkTask.Application.AppData.UserStates.Services;

/// <summary>
/// Сервис для работы со статусами.
/// </summary>
public interface IUserStateService
{
    /// <summary>
    /// Создание статуса.
    /// </summary>
    /// <param name="model">Модель статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного статуса.</returns>
    Task<int> CreateUserStateAsync(CreateUserStateDto model, CancellationToken cancellationToken);
    
    /// <summary>
    /// Изменение статуса.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном статусе.</returns>
    Task<InfoUserStateDto?> UpdateUserStateAsync(int id, UpdateUserStateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление статуса.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteUserStateAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о статусе.</returns>
    Task<InfoUserStateDto?> GetUserStateByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех статусов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список статусов.</returns>
    Task<IEnumerable<InfoUserStateDto>> GetAllUserStates(CancellationToken cancellationToken);
}