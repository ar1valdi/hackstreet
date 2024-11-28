using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Handlers.Measures
{
    [Table("measures")]
    public class Measure
    {
        [Column("date")]
        public DateTime Date { get; set; }
        public Sensor Sensor { get; set; }
        public long SensorId { get; set; }
        [Column("value")] 
        public float Value { get; set; }
        [Column("min_value")] 
        public float MinValue { get; set; }
        [Column("max_value")] 
        public float MaxValue { get; set; }
    }
}
