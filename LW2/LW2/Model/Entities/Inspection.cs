using System.ComponentModel.DataAnnotations.Schema;

namespace LW2.Model.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("failure_reason")]
        public string? FailureReason { get; set; }
        [Column("result")]
        public required string Result { get; set; }
        public Employee? Employee { get; set; }
        public required Equipment Equipment { get; set; }
    }
}
