namespace LW2.Model.Entities;

public partial class Equipment
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public int ProductionArea { get; set; }

    public virtual ICollection<Failure> Failures { get; set; } = [];

    public virtual ICollection<Inspection> Inspections { get; set; } = [];

    public virtual ProductionArea ProductionAreaNavigation { get; set; } = null!;

    public virtual EquipmentType TypeNavigation { get; set; } = null!;
}
