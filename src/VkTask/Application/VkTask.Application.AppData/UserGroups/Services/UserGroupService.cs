using AutoMapper;
using VkTask.Application.AppData.UserGroups.Repositories;
using VkTask.Contracts.UserGroups;
using VkTask.Domain.UserGroups;

namespace VkTask.Application.AppData.UserGroups.Services;

/// <inheritdoc/>
public class UserGroupService : IUserGroupService
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IMapper _mapper;

    public UserGroupService(IUserGroupRepository userGroupRepository, IMapper mapper)
    {
        _userGroupRepository = userGroupRepository;
        _mapper = mapper;
    }

     /// <inheritdoc />
    public async Task<int> CreateUserGroupAsync(CreateUserGroupDto dto, CancellationToken cancellation)
     { 
         var entity = _mapper.Map<CreateUserGroupDto, UserGroup>(dto); 
         
         return await _userGroupRepository.CreateAsync(entity, cancellation);
     }

     /// <inheritdoc/>
    public async Task<InfoUserGroupDto?> UpdateUserGroupAsync(int id, UpdateUserGroupDto dto, CancellationToken cancellationToken)
    {
        var userGroup = await _userGroupRepository.GetByIdAsync(id, cancellationToken);
        if (userGroup == null)
        {
            return null;
        }
        
        var result = _mapper.Map(dto, userGroup); 
        
        return await _userGroupRepository.UpdateAsync(result, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteUserGroupAsync(int id, CancellationToken cancellationToken)
    {
        var result = _userGroupRepository.DeleteAsync(id, cancellationToken);
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoUserGroupDto?> GetUserGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _userGroupRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<UserGroup?, InfoUserGroupDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserGroupDto>> GetAllUserGroups(CancellationToken cancellationToken)
    {
        var entities = _userGroupRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}