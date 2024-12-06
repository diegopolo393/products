using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductosRepaso.Models;

namespace ProductosRepaso.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Usuario);
            builder.Property(x => x.Usuario).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(500).IsRequired();
        }
    }
}
