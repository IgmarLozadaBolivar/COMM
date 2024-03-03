using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("User");

        builder.Property(e => e.Id).HasComment("Identificador de usuario");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasComment("Nombre del usuario");
        builder.Property(e => e.Password)
            .HasMaxLength(255)
            .HasComment("Contraseña del usuario");

        builder.HasMany(p => p.Rols)
            .WithMany(r => r.Users)
            .UsingEntity<UserRol>(

                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UserRols)
                    .HasForeignKey(ut => ut.IdRolFK),


                j => j
                    .HasOne(et => et.User)
                    .WithMany(et => et.UserRols)
                    .HasForeignKey(el => el.IdUserFK),

                j =>
                {
                    j.ToTable("user_rol");
                    j.HasKey(t => new { t.IdUserFK, t.IdRolFK });

                });

        builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.IdUserFK);
    }
}