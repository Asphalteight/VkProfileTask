using AutoMapper;
using VkTask.Application.AppData.UserStates.Repositories;
using VkTask.Contracts.UserStates;
using VkTask.Domain.UserStates;

namespace VkTask.Application.AppData.UserStates.Services;

/// <inheritdoc/>
public class UserStateService : IUserStateService
{
    private readonly IUserStateRepository _userStateRepository;
    private readonly IMapper _mapper;

    public UserStateService(IUserStateRepository userStateRepository, IMapper mapper)
    {
        _userStateRepository = userStateRepository;
        _mapper = mapper;
    }

     /// <inheritdoc />
    public async Task<int> CreateUserStateAsync(CreateUserStateDto dto, CancellationToken cancellation)
     { 
         var entity = _mapper.Map<CreateUserStateDto, UserState>(dto); 
         
         return await _userStateRepository.CreateAsync(entity, cancellation);
     }
     
    /// <inheritdoc/>
    public async Task<InfoUserStateDto?> UpdateUserStateAsync(int id, UpdateUserStateDto dto, CancellationToken cancellationToken)
    {
        var userState = await _userStateRepository.GetByIdAsync(id, cancellationToken);
        if (userState == null)
        {
            return null;
        }
        
        var result = _mapper.Map(dto, userState); 
        
        return await _userStateRepository.UpdateAsync(result, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteUserStateAsync(int id, CancellationToken cancellationToken)
    {
        var result = _userStateRepository.DeleteAsync(id, cancellationToken);
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoUserStateDto?> GetUserStateByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _userStateRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<UserState?, InfoUserStateDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserStateDto>> GetAllUserStates(CancellationToken cancellationToken)
    {
        var entities = _userStateRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}