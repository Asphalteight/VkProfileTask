using System.Net;
using Board.Contracts.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VkTask.Application.AppData.Users.Services;
using VkTask.Contracts.Users;

namespace VkTask.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с пользователями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[AllowAnonymous]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="UserController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="userService">Сервис пользователей.</param>
    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    /// <summary>
    /// Создание нового пользователя.
    /// </summary>
    /// <param name="dto">Модель создания пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Пользователь успешно создан.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор зарегистрированного пользователя.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> RegisterUser([FromQuery] CreateUserDto dto, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(dto, cancellationToken);

        if (result == 0)
        {
            return BadRequest("Ошибка при создании нового пользователя");
        }
        _logger.LogInformation("Зарегистрирован новый пользователь с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }
    
    /// <summary>
    /// Обновить пользователя.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="404">Пользователь с указанным идентификатором не найден.</response>
    /// <returns>Модель обновленного пользователя.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateUserDto dto, CancellationToken cancellationToken)
    {
        var result = await _userService.UpdateUserAsync(id, dto, cancellationToken);
        
        if (result == null)
        {
            return BadRequest("Ошибка при изменении пользователя");
        }
        _logger.LogInformation("Обновлен пользователь с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить пользователя по идентификатору.
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
        var result = await _userService.DeleteUserAsync(id, cancellationToken);

        if (result == false)
        {
            return BadRequest("Ошибка при удалении пользователя");
        }
        _logger.LogInformation("Удален пользователь с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
    
    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Пользователь с указанным идентификатором не найден.</response>
    /// <returns>Модель пользователя.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _userService.GetUserByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошен пользователь с идентификатором: {0}", id);

        if (result != null)
        {
            return Ok(result);
        }
        _logger.LogError("Пользователь с запрашиваемым идентификатором \"{0}\" не найден", id);
        
        return NotFound();
    }
    
    /// <summary>
    /// Получить список пользователей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей пользователей.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoUserDto>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<InfoUserDto>> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все пользователи");
        var result = await _userService.GetAllUsers(cancellationToken);
        
        return result;
    }
}