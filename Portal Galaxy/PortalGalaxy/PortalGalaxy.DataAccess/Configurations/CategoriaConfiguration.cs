using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalGalaxy.Entities;

namespace PortalGalaxy.DataAccess.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasData(new List<Categoria>
        {
            new() { Id = 1, Nombre = ".NET" },
            new() { Id = 2, Nombre = "Java" },
            new() { Id = 3, Nombre = "AWS" },
            new() { Id = 4, Nombre = "Azure" },
            new() { Id = 5, Nombre = "Python" },
        });

        builder.HasQueryFilter(p => p.Estado);
    }
}