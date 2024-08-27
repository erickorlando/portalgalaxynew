using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IInscripcionProxy : ICrudRestHelper<InscripcionDtoRequest, InscripcionDtoResponse>
{
    Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request);

    Task<PaginationResponse<InscripcionDtoResponse>> ListTalleresAsync(int pagina, int filas);

    Task<BaseResponse> CambiarSituacionAsync(int id);

    Task InscripcionMasivaAsync(InscripcionMasivaDtoRequest request);
}