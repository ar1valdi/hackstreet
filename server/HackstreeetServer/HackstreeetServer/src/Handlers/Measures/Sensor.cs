using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Handlers.Measures
{
    [Table("sensors")]
    public class Sensor
    {
        [Column("id")] 
        public long Id { get; set; }
        public Station ForStation { get; set; }
        public long StationId { get; set; }
        [Column("keycode")] 
        public string Keycode { get; set; }
        [Column("sensing")] 
        public string Sensing { get; set; }
        public List<Measure> Measures { get; internal set; }
    }
}
