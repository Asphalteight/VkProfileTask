using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VkTask.Application.AppData.UserGroups.Repositories;
using VkTask.Contracts.UserGroups;
using VkTask.Domain.UserGroups;
using VkTask.Infrastructure.Repository;

namespace VkTask.Infrastructure.DataAccess.UserGroups.Repository;

/// <inheritdoc/> 
public class UserGroupRepository : IUserGroupRepository
{
    private readonly IRepository<UserGroup> _repository;
    private readonly IMapper _mapper;
    
    public UserGroupRepository(IRepository<UserGroup> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(UserGroup model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoUserGroupDto> UpdateAsync(UserGroup model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<UserGroup, InfoUserGroupDto>(model);
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
    public async Task<UserGroup?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
         var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
         return result;
    }

    /// <inheritdoc/>
    public async Task<UserGroup?> FindWhere(Expression<Func<UserGroup, bool>> predicate, CancellationToken cancellation)
    {
        var data = _repository.GetAllFiltered(predicate);

        var user = await data.Where(predicate).FirstOrDefaultAsync(cancellation);

        return user;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserGroupDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoUserGroupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}