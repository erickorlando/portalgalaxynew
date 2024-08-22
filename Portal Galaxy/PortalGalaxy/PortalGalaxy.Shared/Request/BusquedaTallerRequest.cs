using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class BusquedaTallerRequest : RequestBase
{
    [StringLength(3, ErrorMessage = Constantes.CampoLargo)]
    public string? Nombre { get; set; } 
    public int? CategoriaId { get; set; }
    public int? Situacion { get; set; }
}