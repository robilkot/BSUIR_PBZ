using System.ComponentModel.DataAnnotations.Schema;

namespace LW2.Model.Entities
{
    public class Failure
    {
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("failure_reason")]
        public required string FailureReason { get; set; }
        public Employee? LastInspectingEmployee { get; set; }
        public required Equipment Equipment { get; set; }
    }
}
