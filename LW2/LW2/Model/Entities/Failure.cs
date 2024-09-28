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
        [Column("last_inspecting_employee_id")]
        public int? LastInspectingEmployeeId { get; set; }
        [Column("equipment_id")]
        public required int EquipmentId { get; set; }
    }
}
