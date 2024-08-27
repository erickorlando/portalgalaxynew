using PortalGalaxy.Shared.Response;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Text;

namespace PortalGalaxy.Client.Proxy.Services;

public class RestBase
{
    protected readonly HttpClient HttpClient;

    protected string BaseUrl { get; set; }

    protected RestBase(string baseUrl, HttpClient httpClient)
    {
        BaseUrl = baseUrl;
        HttpClient = httpClient;
    }

    protected async Task<TOutput> SendAsync<TInput, TOutput>(TInput request, HttpMethod method, string url)
        where TOutput : BaseResponse
    {
        var requestMessage = new HttpRequestMessage(method, $"{BaseUrl}/{url}");
        requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await HttpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<TOutput>();
            return errorResponse!;
        }

        var result = await response.Content.ReadFromJsonAsync<TOutput>();
        if (result != null)
        {
            return result;
        }

        throw new InvalidOperationException($"Error en la solicitud {url}");
    }

    protected async Task<TOutput> SendAsync<TOutput>(string url)
    where TOutput : BaseResponse
    {
        try
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/{url}");

            var response = await HttpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                throw new InvalidOperationException(errorResponse!.ErrorMessage);
            }

            var result = await response.Content.ReadFromJsonAsync<TOutput>();
            if (result is not null)
            {
                return result;
            }

            throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en la solicitud {ex.Message}");
        }
    }
    
    protected async Task<TOutput> SendAsync<TOutput>(string url, HttpMethod httpMethod)
    where TOutput : BaseResponse
    {
        try
        {
            var requestMessage = new HttpRequestMessage(httpMethod, $"{BaseUrl}/{url}");

            var response = await HttpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                throw new InvalidOperationException(errorResponse!.ErrorMessage);
            }

            var result = await response.Content.ReadFromJsonAsync<TOutput>();
            if (result is not null)
            {
                return result;
            }

            throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en la solicitud {ex.Message}");
        }
    }
}