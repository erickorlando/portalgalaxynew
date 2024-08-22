using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Configuracion;

namespace PortalGalaxy.Services.Implementaciones;

public class FileUploader : IFileUploader
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<FileUploader> _logger;

    public FileUploader(IOptions<AppSettings> options, ILogger<FileUploader> logger)
    {
        _appSettings = options.Value;
        _logger = logger;
    }

    public async Task<string> UploadFileAsync(string? base64Imagen, string? archivo)
    {
        if (string.IsNullOrWhiteSpace(base64Imagen) || string.IsNullOrWhiteSpace(archivo))
            return string.Empty;

        try
        {
            var client = new BlobServiceClient(_appSettings.StorageConfiguration.Path);
            var container = client.GetBlobContainerClient("portalgalaxy");

            var blob = container.GetBlobClient(archivo);

            await using var stream = new MemoryStream(Convert.FromBase64String(base64Imagen));
            await blob.UploadAsync(stream, overwrite: true);

            _logger.LogInformation("Se subio la imagen a Azure Blob Storage");

            return $"{_appSettings.StorageConfiguration.PublicUrl}/{archivo}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al subir archivos a la cuenta de almacenamiento {Message}", ex.Message);
            return string.Empty;
        }
    }
}
