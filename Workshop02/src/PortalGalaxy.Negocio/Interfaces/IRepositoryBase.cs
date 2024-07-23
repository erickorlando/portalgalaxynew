using PortalGalaxy.Entities;

namespace PortalGalaxy.Negocio.Interfaces
{
    public interface IRepositoryBase<TEntity>
    where TEntity : EntityBase
    {
        ICollection<TEntity> List();

        void Add(TEntity entity);
    }
}
