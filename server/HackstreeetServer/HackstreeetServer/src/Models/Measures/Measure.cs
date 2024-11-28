﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackstreeetServer.src.Models.Measures
{
    [Table("measures")]
    public class Measure
    {
        [Key]
        [Column("date")]
        public DateTime Date { get; set; }
        public Station Station { get; set; }
        [Column("station_id")]
        public long StationId { get; set; }
        [Column("value")]
        public float? Value { get; set; }
        [Column("min_value")]
        public float? MinValue { get; set; }
        [Column("max_value")]
        public float? MaxValue { get; set; }
        [Column("sensing")]
        public string Sensing { get; set; }
        [Column("category")]
        public string Category { get; set; }
    }
}
