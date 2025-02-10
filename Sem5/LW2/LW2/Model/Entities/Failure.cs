namespace LW2.Model.Entities;

public partial class Failure
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? FailureReason { get; set; }

    public int? LastInspectingEmployeeId { get; set; }

    public int EquipmentId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Employee? LastInspectingEmployee { get; set; }
}
