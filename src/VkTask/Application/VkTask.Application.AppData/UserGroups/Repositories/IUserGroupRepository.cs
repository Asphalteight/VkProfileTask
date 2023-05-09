using System.Linq.Expressions;
using VkTask.Contracts.UserGroups;
using VkTask.Domain.UserGroups;

namespace VkTask.Application.AppData.UserGroups.Repositories;

/// <summary>
/// Репозиторий для работы с группами.
/// </summary>
public interface IUserGroupRepository
{
    /// <summary>
    /// Создание группы.
    /// </summary>
    /// <param name="model">Модель группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной группы.</returns>
    Task<int> CreateAsync(UserGroup model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение группы.
    /// </summary>
    /// <param name="model">Модель группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененной группе.</returns>
    Task<InfoUserGroupDto> UpdateAsync(UserGroup model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление группы.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель группы.</returns>
    Task<UserGroup?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Поиск по фильтру.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellation"></param>
    /// <returns>Модель группы</returns>
    Task<UserGroup?> FindWhere(Expression<Func<UserGroup, bool>> predicate, CancellationToken cancellation);
    
    /// <summary>
    /// Получение всех групп.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех групп.</returns>
    Task<IEnumerable<InfoUserGroupDto>> GetAllAsync(CancellationToken cancellationToken);
}