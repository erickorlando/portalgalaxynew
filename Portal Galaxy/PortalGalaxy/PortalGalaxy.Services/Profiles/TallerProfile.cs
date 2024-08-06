using AutoMapper;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class TallerProfile : Profile
{
    public TallerProfile()
    {
        CreateMap<TallerInfo, TallerDtoResponse>();

        CreateMap<TallerDtoRequest, Taller>()
            .ReverseMap();
    }
}