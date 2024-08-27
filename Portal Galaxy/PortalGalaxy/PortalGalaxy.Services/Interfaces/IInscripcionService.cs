using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface IInscripcionService
{
    Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request);

    Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(string email, int pagina = 1, int filas = 5);

    Task<BaseResponse> AddAsync(string email, InscripcionDtoRequest request);
    Task<BaseResponseGeneric<InscripcionDtoRequest>> FindByIdAsync(int id);
    Task<BaseResponse> UpdateAsync(string email, int id, InscripcionDtoRequest request);
    Task<BaseResponse> DeleteAsync(int id);
    Task<BaseResponse> AddMasivaAsync(InscripcionMasivaDtoRequest request);
    Task<BaseResponse> CambiarSituacionAsync(int id);
}