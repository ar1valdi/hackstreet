using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {

        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasOne(s => s.ForStation)
                .WithMany(s => s.Sensors)
                .HasForeignKey(s => s.StationId);
        }
    }
}
