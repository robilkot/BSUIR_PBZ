namespace LW2.Model.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string PersonnelNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public virtual ICollection<Failure> Failures { get; set; } = [];

    public virtual ICollection<Inspection> Inspections { get; set; } = [];
}
