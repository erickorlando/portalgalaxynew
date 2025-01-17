﻿using PortalGalaxy.Entities;

namespace PortalGalaxy.Repositories.Interfaces;

public interface IAlumnoRepository : IRepositoryBase<Alumno>
{
    Task<Alumno?> FindByEmailAsync(string email, bool asTracking = false);
}