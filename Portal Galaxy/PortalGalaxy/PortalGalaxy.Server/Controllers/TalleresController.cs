using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TalleresController : ControllerBase
{
    private readonly ITallerService _service;
    private readonly IPdfService _pdfService;

    public TalleresController(ITallerService service, IPdfService pdfService)
    {
        _service = service;
        _pdfService = pdfService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BusquedaTallerRequest request)
    {
        var response = await _service.ListAsync(request);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost("pdf")]
    public async Task<IActionResult> Pdf(BusquedaTallerRequest request)
    {
        var response = await _pdfService.Generar(request);
        if (response.Success)
        {
            var bytes = response.Data.GeneratePdf();

            return File(new MemoryStream(bytes), "application/pdf");
        }

        return Ok(response);
    }
}