using AutoMapper;
using VkTask.Application.AppData.UserGroups.Repositories;
using VkTask.Application.AppData.Users.Repositories;
using VkTask.Contracts.Users;
using VkTask.Domain.Users;

namespace VkTask.Application.AppData.Users.Services;

/// <inheritdoc/>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUserGroupRepository userGroupRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _userGroupRepository = userGroupRepository;
        _mapper = mapper;
    }

     /// <inheritdoc />
    public async Task<int> CreateUserAsync(CreateUserDto userDto, CancellationToken cancellationToken)
     {
         var existingUser = await _userRepository.FindWhere(acc => acc.Login == userDto.Login, cancellationToken);
         var adminId = await _userGroupRepository.FindWhere(adm => adm.Code == "Admin", cancellationToken);
         
         if (existingUser != null || userDto.UserGroupId == adminId!.Id)
         {
             return 0;
         }
         
         var user = _mapper.Map<CreateUserDto, User>(userDto);
         await _userRepository.CreateAsync(user, cancellationToken);
         await Task.Delay(5000, cancellationToken);
         
         return user.Id;
    }

     /// <inheritdoc/>
    public async Task<InfoUserDto?> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.FindWhere(acc => acc.Login == dto.Login, cancellationToken);
        var adminId = await _userGroupRepository.FindWhere(adm => adm.Code == "Admin", cancellationToken);
        
        if (existingUser != null || dto.UserGroupId == adminId!.Id)
        {
            return null;
        }
        
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        var entity = _mapper.Map(dto, user);

        return await _userRepository.UpdateAsync(entity!, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            return false;
        }
        user.UserStateId = 2;
        await _userRepository.UpdateAsync(user, cancellationToken);
            
        return true;
    }

    /// <inheritdoc/>
    public async Task<InfoUserDto?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<User?, InfoUserDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserDto>> GetAllUsers(CancellationToken cancellationToken)
    {
        var entities = _userRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}