using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class InscripcionDtoRequest
{
    [Range(1, 9999, ErrorMessage = "Debe escoger el taller para la inscripcion")]
    public int TallerId { get; set; }
    public int Situacion { get; set; }
}