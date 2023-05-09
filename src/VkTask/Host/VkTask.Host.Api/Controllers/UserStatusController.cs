using System.Net;
using Board.Contracts.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VkTask.Application.AppData.UserStates.Services;
using VkTask.Contracts.UserStates;
using VkTask.Contracts.Users;

namespace VkTask.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы со статусами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[AllowAnonymous]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class UserStateController : ControllerBase
{
    private readonly ILogger<UserStateController> _logger;
    private readonly IUserStateService _userStateService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="UserStateController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="userStateService">Сервис пользователей.</param>
    public UserStateController(ILogger<UserStateController> logger, IUserStateService userStateService)
    {
        _logger = logger;
        _userStateService = userStateService;
    }

    /// <summary>
    /// Создать новый статус.
    /// </summary>
    /// <param name="dto">Модель создания статуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Статус успешно создана.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного статуса.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> RegisterUser([FromQuery] CreateUserStateDto dto, CancellationToken cancellationToken)
    {
        var result = await _userStateService.CreateUserStateAsync(dto, cancellationToken);
        _logger.LogInformation("Создан новый статус с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }
    
    /// <summary>
    /// Обновить статус.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления стутуса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Статус с указанным идентификатором не найден.</response>
    /// <returns>Модель обновленного стутуса.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateUserStateDto dto, CancellationToken cancellationToken)
    {
        var result = await _userStateService.UpdateUserStateAsync(id, dto, cancellationToken);
        
        if (result == null)
        {
            return BadRequest("Ошибка при обновлении статуса");
        }
        _logger.LogInformation("Обновлен статус с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить стутус по идентификатору.
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
        var result = await _userStateService.DeleteUserStateAsync(id, cancellationToken);
        _logger.LogInformation("Удален стутус с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
    
    /// <summary>
    /// Получить статус по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Статус с указанным идентификатором не найдена.</response>
    /// <returns>Модель статуса.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _userStateService.GetUserStateByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошен статус с идентификатором: {0}", id);

        if (result != null)
        {
            return Ok(result);
        }
        _logger.LogError("Статус с запрашиваемым идентификатором \"{0}\" не найден", id);
        
        return NotFound();
    }
    
    /// <summary>
    /// Получить список статусов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей статусов.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoUserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все статусы");
        var result = await _userStateService.GetAllUserStates(cancellationToken);

        return await Task.Run(() => Ok(result), cancellationToken);
    }
}