using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class MeasureConfiguration : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.HasOne(s => s.Station)
                .WithMany(s => s.Measures)
                .HasForeignKey(s => s.StationId);
        }
    }
}
