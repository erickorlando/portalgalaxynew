using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Services.Utils;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class TallerService : ITallerService
{
    private readonly ITallerRepository _repository;
    private readonly ILogger<TallerService> _logger;
    private readonly IMapper _mapper;

    public TallerService(ITallerRepository repository, ILogger<TallerService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request)
    {
        var response = new PaginationResponse<TallerDtoResponse>();
        try
        {
            var tupla = await _repository.ListarTalleresAsync(request.Nombre, request.CategoriaId, request.Situacion, request.Pagina, request.Filas);

            response.Data = _mapper.Map<ICollection<TallerDtoResponse>>(tupla.Collection);
            response.TotalPages = Helper.GetTotalPages(tupla.Total, request.Filas);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar los Talleres";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public Task<PaginationResponse<InscritosPorTallerDtoResponse>> ListAsync(BusquedaInscritosPorTallerRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponseGeneric<ICollection<TallerSimpleDtoResponse>>> ListSimpleAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PaginationResponse<TallerHomeDtoResponse>> ListarTalleresHomeAsync(BusquedaTallerHomeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse> AddAsync(TallerDtoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponseGeneric<TallerDtoRequest>> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponseGeneric<TallerHomeDtoResponse>> GetTallerHomeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponseGeneric<ICollection<TalleresPorMesDto>>> ReporteTalleresPorMes(int anio)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponseGeneric<ICollection<TalleresPorInstructorDto>>> ReporteTalleresPorInstructor(int anio)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse> UpdateAsync(int id, TallerDtoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}