﻿using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Entities;

namespace PortalGalaxy.Repositories.Interfaces;

public interface ITallerRepository : IRepositoryBase<Taller>
{
    Task<ICollection<Taller>> ListarAsync();

    Task<(ICollection<TallerInfo> Collection, int Total)> ListarTalleresAsync(string? nombre, int? categoriaId, int? situacion, int pagina,
        int filas);

    Task<(ICollection<TallerHomeInfo> Collection, int Total)> ListarTalleresHomeAsync(string? nombre, int? instructorId,
        DateOnly? fechaInicio, DateOnly? fechaFin, int pagina, int filas);

    /// <summary>
    /// Lista de Inscritos por Taller
    /// </summary>
    Task<(ICollection<InscritosPorTallerInfo> Collection, int Total)> ListAsync(int? instructorId, string? taller,
        int? situacion, DateOnly? fechaInicio, DateOnly? fechaFin, int pagina, int filas);

    Task<TallerHomeInfo?> ObtenerTallerHomeAsync(int id);

    Task<ICollection<TalleresPorMesInfo>> ListarTalleresPorMesAsync(int anio);

    Task<ICollection<TalleresPorInstructorInfo>> ListarTalleresPorInstructorAsync(int anio);
}