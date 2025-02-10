namespace LW2.Model.Entities;

public partial class Inspection
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Result { get; set; } = null!;

    public string? FailureReason { get; set; }

    public int EmployeeId { get; set; }

    public int EquipmentId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;
}
