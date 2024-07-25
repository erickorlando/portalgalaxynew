using PortalGalaxy.Entities;

namespace PortalGalaxy.Services.Utils;

public static class Helper
{
    public static void InsertarAuditoria(this EntityBase entity, string usuario)
    {
        entity.UsuarioCreacion = usuario;
        entity.FechaCreacion = DateTime.UtcNow;
    }

    public static void ActualizarAuditoria(this EntityBase entity, string usuario)
    {
        entity.UsuarioActualizacion = usuario;
        entity.FechaActualizacion = DateTime.UtcNow;
    }
}