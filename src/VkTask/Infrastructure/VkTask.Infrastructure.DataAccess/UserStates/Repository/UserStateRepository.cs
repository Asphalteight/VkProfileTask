using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VkTask.Application.AppData.UserStates.Repositories;
using VkTask.Contracts.UserStates;
using VkTask.Domain.UserStates;
using VkTask.Infrastructure.Repository;

namespace VkTask.Infrastructure.DataAccess.UserStates.Repository;

/// <inheritdoc/> 
public class UserStateRepository : IUserStateRepository
{
    private readonly IRepository<UserState> _repository;
    private readonly IMapper _mapper;
    
    public UserStateRepository(IRepository<UserState> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(UserState model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoUserStateDto> UpdateAsync(UserState model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<UserState, InfoUserStateDto>(model);
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
        if (model == null) return false;
        await _repository.DeleteAsync(model, cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<UserState?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
         var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
         return result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserStateDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoUserStateDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}