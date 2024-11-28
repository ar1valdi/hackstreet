using HackstreeetServer.src.Handlers.Measures;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class MeasureConfiguration : IEntityTypeConfiguration<Measure>
    {

        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.HasOne(s => s.Sensor)
                .WithMany(s => s.Measures)
                .HasForeignKey(s => s.SensorId);
        }
    }
}
