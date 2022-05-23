using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Core;

namespace Pokemon.Infrastructure.Config
{
    public class PokemonConfiguration : IEntityTypeConfiguration<PokemonInfo>
    {
        public void Configure(EntityTypeBuilder<PokemonInfo> builder)
        {
            builder.Property(p => p.PokemonInfoId).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(100);
        }
    }
}
