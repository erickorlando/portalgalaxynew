using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Entities
{
    public class Alumno : EntityBase
    {
        [StringLength(100)]
        public string NombreCompleto { get; set; } = default!;

        [StringLength(200)]
        public string Correo { get; set; } = default!;
    }
}
