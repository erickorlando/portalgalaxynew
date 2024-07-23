using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Negocio.Interfaces;

namespace PortalGalaxy.Negocio.Implementaciones;

public class AlumnoRepository : RepositoryBase<Alumno>, IAlumnoRepository
{
    public AlumnoRepository(PortalGalaxyDbContext dbContext) 
        : base(dbContext)
    {
    }
}