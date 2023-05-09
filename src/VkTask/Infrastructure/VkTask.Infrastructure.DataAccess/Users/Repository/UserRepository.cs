using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VkTask.Application.AppData.Users.Repositories;
using VkTask.Contracts.Users;
using VkTask.Domain.Users;
using VkTask.Infrastructure.Repository;

namespace VkTask.Infrastructure.DataAccess.Users.Repository;

/// <inheritdoc/> 
public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;
    
    public UserRepository(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(User model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoUserDto> UpdateAsync(User model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<User, InfoUserDto>(model);
    }
    
    // Реализация метода фактического удаления из БД:
    
    // /// <inheritdoc/> 
    // public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    // {
    //     var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
    //     if (model == null) return false;
    //     await _repository.DeleteAsync(model, cancellationToken);
    //     return true;
    // }
    
    /// <inheritdoc/> 
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
         var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
         return result;
    }

    /// <inheritdoc/>
    public async Task<User?> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken cancellation)
    {
        var data = _repository.GetAllFiltered(predicate);

        var user = await data.Where(predicate).FirstOrDefaultAsync(cancellation);

        return user;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoUserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoUserDto>(_mapper.ConfigurationProvider).OrderBy(a => a.Id).ToListAsync(cancellationToken);
    }
}