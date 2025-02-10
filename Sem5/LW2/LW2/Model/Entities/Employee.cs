namespace LW2.Model.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string PersonnelNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public virtual ICollection<Failure> Failures { get; set; } = [];

    public virtual ICollection<Inspection> Inspections { get; set; } = [];
}
