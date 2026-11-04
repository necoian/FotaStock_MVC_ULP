using FotaStock.Web.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using FotaStock.Web.Entities;
using System.Linq.Expressions;

namespace FotaStock.Web.Repositories;


public class GenericRepository<TEntity>(AppDbContext _dbContext) where TEntity : class
{
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,object>>[] includes)
    {

        IQueryable<TEntity> query = _dbContext.Set<TEntity>();

        foreach(var include in includes)query = query.Include(include);

        return await query.ToListAsync();
    }

    public async Task<PaginatedList<TEntity>> GetByPaginationAsync(int pageIndex, int pageSize)
    {
        var entities = await _dbContext.Set<TEntity>().Skip((pageIndex -  1) * pageSize).Take(pageSize).ToListAsync();
        
        var count = await _dbContext.Set<TEntity>().CountAsync();

        var totalPages = (int)Math.Ceiling((double)count / pageSize);
        return new PaginatedList<TEntity>(entities, pageIndex, totalPages);

    }

    public async Task AddAsync(TEntity entity)
    {
        

        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<TEntity?> GetbyIdAsync(int entityId) {
        
        return await _dbContext.Set<TEntity>().FindAsync(entityId);
    }

    public async Task EditAsync(TEntity entity)
    {
        

        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task DeleteAsync(TEntity entity)
    {
        

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();

    }


}