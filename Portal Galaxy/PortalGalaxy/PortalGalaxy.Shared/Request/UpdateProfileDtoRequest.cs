using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class UpdateProfileDtoRequest
{
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Nro. Documento")]
    public string NroDocumento { get; set; } = default!;
    
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Nombre Completo")]
    public string NombreCompleto { get; set; } = default!;
    
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Telefono { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Departamento { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Provincia { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Distrito { get; set; } = default!;
}