using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class UserProxy : RestBase, IUserProxy
{
    private readonly HttpClient _httpClient;

    public UserProxy(HttpClient httpClient)
        : base("api/Users", httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/Login", request);
        var loginResponse = await response.Content.ReadFromJsonAsync<LoginDtoResponse>();

        return loginResponse!;
    }

    public async Task Register(RegistrarUsuarioDto request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/Register", request);

        //response.EnsureSuccessStatusCode(); // Solo en caso de que no sepa el error en el backend

        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
            throw new InvalidOperationException(response.ReasonPhrase);
    }

    public async Task SendTokenToResetPassword(GenerateTokenToResetDtoRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/SendTokenToResetPassword", request);
        if (!response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
            throw new InvalidOperationException(jsonResponse!.ErrorMessage);
        }
    }

    public async Task<BaseResponse> ResetPassword(ResetPasswordDtoRequest request)
    {
        var response = await SendAsync<ResetPasswordDtoRequest, BaseResponse>(request, 
                HttpMethod.Post, "ResetPassword");

        return response;
    }

    public async Task<BaseResponse> ChangePasswordAsync(ChangePasswordDtoRequest request)
    {
        var response = await SendAsync<ChangePasswordDtoRequest, BaseResponse>(request,
            HttpMethod.Post, "ChangePassword");

        return response;
    }

    public async Task<BaseResponse> UpdateProfileAsync(UpdateProfileDtoRequest request)
    {
        var response = await SendAsync<UpdateProfileDtoRequest, BaseResponse>(request,
            HttpMethod.Post, "UpdateProfile");

        return response;
    }

    public async Task<BaseResponseGeneric<AlumnoDtoResponse>> GetProfileAsync()
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<AlumnoDtoResponse>>("api/Users/Get");

        if (response is { Success: true, Data: not null })
        {
            return response;
        }

        throw new InvalidOperationException(response!.ErrorMessage);
    }
}