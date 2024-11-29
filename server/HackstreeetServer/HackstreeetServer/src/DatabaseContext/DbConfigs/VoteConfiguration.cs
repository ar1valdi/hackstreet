using HackstreeetServer.src.Models.Suggestions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasOne(v => v.Suggestion)
                .WithMany(s => s.Votes)
                .HasForeignKey(v => v.SuggestionId);
        }
    }
}
