using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface IUserService
{
    Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);

    Task<BaseResponse> RegisterAsync(RegistrarUsuarioDto request);

    Task<BaseResponse> SendTokenToResetPasswordAsync(GenerateTokenToResetDtoRequest request);

    Task<BaseResponse> ResetPasswordAsync(ResetPasswordDtoRequest request);

    Task<BaseResponse> ChangePasswordAsync(ChangePasswordDtoRequest request, string email);

    Task<BaseResponse> UpdateProfileAsync(UpdateProfileDtoRequest request);

    Task<BaseResponseGeneric<AlumnoDtoResponse>> GetProfileAsync(BusquedaPerfilDtoRequest request);
}