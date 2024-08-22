using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class ChangePasswordDtoRequest
{
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Clave anterior")]
    public string OldPassword { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Compare(nameof(ConfirmPassword))]
    [Display(Name = "Nueva clave")]
    public string NewPassword { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Confirmar clave")]
    public string ConfirmPassword { get; set; } = default!;

}