using VkTask.Contracts.UserGroups;

namespace VkTask.Application.AppData.UserGroups.Services;

/// <summary>
/// Сервис для работы с группами.
/// </summary>
public interface IUserGroupService
{
    /// <summary>
    /// Создание группы.
    /// </summary>
    /// <param name="model">Модель группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной группы.</returns>
    Task<int> CreateUserGroupAsync(CreateUserGroupDto model, CancellationToken cancellationToken);
    
    /// <summary>
    /// Изменение группы.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененной группе.</returns>
    Task<InfoUserGroupDto?> UpdateUserGroupAsync(int id, UpdateUserGroupDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление группы.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteUserGroupAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о группе.</returns>
    Task<InfoUserGroupDto?> GetUserGroupByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех групп.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список групп.</returns>
    Task<IEnumerable<InfoUserGroupDto>> GetAllUserGroups(CancellationToken cancellationToken);
}