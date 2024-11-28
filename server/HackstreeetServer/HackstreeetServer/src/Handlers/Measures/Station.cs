using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Handlers.Measures
{
    [Table("stations")]
    public class Station
    {
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
