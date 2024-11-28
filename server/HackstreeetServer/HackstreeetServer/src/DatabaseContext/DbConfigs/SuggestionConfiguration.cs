using HackstreeetServer.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<Suggestion>
    {
        private const string TABLE_NAME = "suggestions";

        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder
                .Property(b => b.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(b => b.Description)
                .HasColumnName("description");

            builder
                .Property(b => b.AddedBy)
                .HasColumnName("added_by");
        }
    }
}
