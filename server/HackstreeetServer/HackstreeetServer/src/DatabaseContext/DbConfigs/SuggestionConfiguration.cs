using HackstreeetServer.src.Models.Suggestions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.HasMany(b => b.Votes)
                .WithOne(b => b.Suggestion);
        }
    }
}
