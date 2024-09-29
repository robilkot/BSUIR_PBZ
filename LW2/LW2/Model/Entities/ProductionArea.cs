namespace LW2.Model.Entities;

public partial class ProductionArea
{
    public int Id { get; set; }

    public string Number { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Equipment> Equipment { get; set; } = [];
}
