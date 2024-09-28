namespace LW2.Model.Entities;

public partial class ProductionArea
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = [];
}
