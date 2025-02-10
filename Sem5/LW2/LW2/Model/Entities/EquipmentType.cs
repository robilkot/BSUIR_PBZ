namespace LW2.Model.Entities;

public partial class EquipmentType
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Equipment> Equipment { get; set; } = [];
}
