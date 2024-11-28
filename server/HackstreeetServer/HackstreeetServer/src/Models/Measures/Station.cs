using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Models.Measures
{
    [Table("stations")]
    public class Station
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("latitude")]
        public float Latitude { get; set; }
        [Column("longitude")]
        public float Longitude { get; set; }
        [Column("station_type")]
        public StationType Type { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
