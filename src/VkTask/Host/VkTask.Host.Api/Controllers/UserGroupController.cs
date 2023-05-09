using System.Net;
using Board.Contracts.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VkTask.Application.AppData.UserGroups.Services;
using VkTask.Contracts.UserGroups;
using VkTask.Contracts.Users;

namespace VkTask.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с группами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[AllowAnonymous]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class UserGroupController : ControllerBase
{
    private readonly ILogger<UserGroupController> _logger;
    private readonly IUserGroupService _userGroupService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="UserGroupController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="userGroupService">Сервис пользователей.</param>
    public UserGroupController(ILogger<UserGroupController> logger, IUserGroupService userGroupService)
    {
        _logger = logger;
        _userGroupService = userGroupService;
    }

    /// <summary>
    /// Создать новую группу.
    /// </summary>
    /// <param name="dto">Модель создания группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Группа успешно создана.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <returns>Идентификатор созданной группы.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromQuery] CreateUserGroupDto dto, CancellationToken cancellationToken)
    {
        var result = await _userGroupService.CreateUserGroupAsync(dto, cancellationToken);
        _logger.LogInformation("Создана новая группа с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }
    
    /// <summary>
    /// Обновить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления группы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Группа с указанным идентификатором не найдена.</response>
    /// <returns>Модель обновленной группы.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateUserGroupDto dto, CancellationToken cancellationToken)
    {
        var result = await _userGroupService.UpdateUserGroupAsync(id, dto, cancellationToken);
        
        if (result == null)
        {
            return BadRequest("Ошибка при обновлении группы");
        }
        _logger.LogInformation("Обновлена группа с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить группу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="403">Доступ запрещён.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        var result = await _userGroupService.DeleteUserGroupAsync(id, cancellationToken);
        _logger.LogInformation("Удалена группа с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
    
    /// <summary>
    /// Получить группу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Группа с указанным идентификатором не найдена.</response>
    /// <returns>Модель группы.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _userGroupService.GetUserGroupByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошена группа с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Группа с запрашиваемым идентификатором \"{0}\" не найдена", id);
            return NotFound();
        }
        
        return Ok(result);
    }
    
    /// <summary>
    /// Получить список групп.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей групп.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoUserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все группы");
        var result = await _userGroupService.GetAllUserGroups(cancellationToken);

        return await Task.Run(() => Ok(result), cancellationToken);
    }
}