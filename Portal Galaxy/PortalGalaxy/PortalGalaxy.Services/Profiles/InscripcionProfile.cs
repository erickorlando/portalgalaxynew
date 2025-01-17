﻿using AutoMapper;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Entities;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class InscripcionProfile : Profile
{
    public InscripcionProfile()
    {
        CreateMap<Inscripcion, InscripcionDtoResponse>();
        CreateMap<InscripcionDtoRequest, Inscripcion>();

        CreateMap<InscripcionInfo, InscripcionDtoResponse>();
    }
}