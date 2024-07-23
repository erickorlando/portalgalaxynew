using Microsoft.EntityFrameworkCore;
using PortalGalaxy.Entities;
using PortalGalaxy.Negocio.Interfaces;

namespace PortalGalaxy.Negocio.Implementaciones;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    private readonly DbContext _dbContext;

    public RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
  
    public ICollection<TEntity> List()
    {
        return _dbContext.Set<TEntity>()
            .AsNoTracking()
            .ToList();
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }
}