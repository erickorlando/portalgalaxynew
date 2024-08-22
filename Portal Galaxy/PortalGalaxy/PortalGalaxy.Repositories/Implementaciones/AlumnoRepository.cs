using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class AlumnoRepository : RepositoryBase<Alumno>, IAlumnoRepository
{
    public AlumnoRepository(PortalGalaxyDbContext context) : base(context)
    {
    }

    public async Task<Alumno?> FindByEmailAsync(string email, bool asTracking = false)
    {
        Expression<Func<Alumno, bool>> predicado = p => p.Correo == email;

        if (asTracking)
            return await Context.Set<Alumno>().FirstOrDefaultAsync(predicado);
        else
            return await Context.Set<Alumno>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicado);
    }
}