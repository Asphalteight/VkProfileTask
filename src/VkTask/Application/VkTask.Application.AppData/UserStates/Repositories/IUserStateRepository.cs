using VkTask.Contracts.UserStates;
using VkTask.Domain.UserStates;

namespace VkTask.Application.AppData.UserStates.Repositories;

/// <summary>
/// Репозиторий для работы со статусами.
/// </summary>
public interface IUserStateRepository
{
    /// <summary>
    /// Создание статуса.
    /// </summary>
    /// <param name="model">Модель статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного статуса.</returns>
    Task<int> CreateAsync(UserState model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение статуса.
    /// </summary>
    /// <param name="model">Модель статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном статусе.</returns>
    Task<InfoUserStateDto> UpdateAsync(UserState model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление статуса.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель статуса.</returns>
    Task<UserState?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех статусов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех статусов.</returns>
    Task<IEnumerable<InfoUserStateDto>> GetAllAsync(CancellationToken cancellationToken);
}