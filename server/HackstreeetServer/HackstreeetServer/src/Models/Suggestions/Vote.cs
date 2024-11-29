using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Models.Suggestions
{
    [Table("votes")]
    public class Vote
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("suggestion_id")]
        public Guid SuggestionId { get; set; }
        public Suggestion Suggestion { get; set; }
        [Column("value")]
        public char Value { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
