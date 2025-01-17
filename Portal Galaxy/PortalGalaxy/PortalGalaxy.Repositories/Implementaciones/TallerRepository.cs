﻿using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Repositories.Interfaces;
using System.Data;
using System.Globalization;
using Dapper;

namespace PortalGalaxy.Repositories.Implementaciones;

public class TallerRepository(PortalGalaxyDbContext context)
    : RepositoryBase<Taller>(context), ITallerRepository
{
    public async Task<ICollection<Taller>> ListarAsync()
    {
        return await Context.Set<Taller>()
            .Include(p => p.Categoria)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<(ICollection<TallerInfo> Collection, int Total)> ListarTalleresAsync(string? nombre,
        int? categoriaId, int? situacion, int pagina, int filas)
    {
        var tupla = await ListAsync(predicado: p => p.Nombre.Contains(nombre ?? string.Empty)
                                                    && (categoriaId == null || p.CategoriaId == categoriaId)
                                                    && (situacion == null || p.Situacion == (SituacionTaller)situacion),
            selector: p => new TallerInfo
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Fecha = p.FechaInicio,
                Instructor = p.Instructor.Nombres,
                Situacion = p.Situacion.ToString().Replace('_', ' ')
            },
            orderBy: x => x.Id,
            relaciones: "Categoria,Instructor",
            pagina, filas);

        return tupla;
    }

    public async Task<(ICollection<TallerHomeInfo> Collection, int Total)> ListarTalleresHomeAsync(string? nombre, int? instructorId, DateOnly? fechaInicio, DateOnly? fechaFin, int pagina, int filas)
    {
        var tupla = await ListAsync(predicado: p => p.Nombre.Contains(nombre ?? string.Empty)
                                                    && (instructorId == null || p.InstructorId == instructorId)
                                                    && (fechaInicio == null || fechaInicio <= p.FechaInicio)
                                                    && (fechaFin == null || fechaFin >= p.FechaInicio),
                                    selector: p => new TallerHomeInfo
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre,
                                        FechaInicio = p.FechaInicio,
                                        HoraInicio = p.HoraInicio,
                                        PortadaUrl = p.PortadaUrl,
                                        TemarioUrl = p.TemarioUrl,
                                        Descripcion = p.Descripcion,
                                        Instructor = p.Instructor.Nombres
                                    },
                                    orderBy: x => x.Id,
                                    relaciones: "Instructor",
                                    pagina: pagina,
                                    filas: filas);

        return tupla;
    }

    public async Task<(ICollection<InscritosPorTallerInfo> Collection, int Total)> ListAsync(int? instructorId, string? taller, int? situacion, DateOnly? fechaInicio, DateOnly? fechaFin, int pagina,
        int filas)
    {
        var tupla = await ListAsync(predicado: p => p.Nombre.Contains(taller ?? string.Empty)
                                                    && (instructorId == null || p.InstructorId == instructorId)
                                                    && (fechaInicio == null || fechaInicio <= p.FechaInicio)
                                                    && (fechaFin == null || fechaFin >= p.FechaInicio),
            selector: p => new InscritosPorTallerInfo
            {
                Id = p.Id,
                Taller = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Instructor = p.Instructor.Nombres,
                Fecha = p.FechaInicio.ToString(),
                Situacion = p.Situacion.ToString().Replace("_", " "),
                Cantidad = p.Inscripciones.Count,
            },
            orderBy: x => x.Id,
            relaciones: "Instructor",
            pagina: pagina,
            filas: filas);

        return tupla;

    }

    public async Task<TallerHomeInfo?> ObtenerTallerHomeAsync(int id)
    {
        return await Context.Set<Taller>()
            .Where(p => p.Id == id)
            .Select(p => new TallerHomeInfo
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = p.FechaInicio,
                HoraInicio = p.HoraInicio,
                PortadaUrl = p.PortadaUrl,
                TemarioUrl = p.TemarioUrl,
                Descripcion = p.Descripcion,
                Instructor = p.Instructor.Nombres
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<TalleresPorMesInfo>> ListarTalleresPorMesAsync(int anio)
    {
        var query = await Context.Set<Taller>()
            .Where(p => p.FechaInicio.Year == anio)
            .GroupBy(p => p.FechaInicio.Month)
            .Select(p => new TalleresPorMesInfo
            {
                Mes = p.Key.ToString(),
                Cantidad = p.Count()
            })
            .ToListAsync();

        query.ForEach(x => x.Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(x.Mes)));

        return query;
    }

    public async Task<ICollection<TalleresPorInstructorInfo>> ListarTalleresPorInstructorAsync(int anio)
    {
        var query = await Context.Set<Taller>()
            .Include(p => p.Instructor)
            .Where(p => p.FechaInicio.Year == anio)
            .GroupBy(p => p.Instructor.Nombres)
            .Select(p => new TalleresPorInstructorInfo
            {
                Instructor = p.Key,
                Cantidad = p.Count()
            })
            .ToListAsync();

        return query;
    }
}