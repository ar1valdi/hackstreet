using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Models.Suggestions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackstreeetServer.src.DatabaseContext.DbConfigs
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
        }
    }
}
