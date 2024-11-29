using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasMany(s => s.Measures)
                .WithOne(s => s.Station);
        }
    }
}
