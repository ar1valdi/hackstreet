using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HackstreeetServer.src.Models.Suggestions
{
    [Table("suggestions")]
    public class Suggestion
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("latitude")]
        public float Latitude { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("longitude")]
        public float Longitude { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("downgrades")]
        public string? Downgrades { get; set; }
        [Column("duration")]
        public int? Duration { get; set; }  // months
        [Column("added_by")]
        public string? AddedBy { get; set; }
        [Column("water_improvement")]
        public float? WaterImprovement { get; set; }
        [Column("air_improvement")]
        public float? AirImprovement { get; set; }
        [Column("sound_improvement")]
        public float? SoundImprovement { get; set; }
        [Column("light_improvement")]
        public float? LightImprovement { get; set; }
        [NotMapped]
        public int Upvotes { get; set; }
        [NotMapped]
        public int Downvotes { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Vote>? Votes { get; set; }
    }
}
