using System.ComponentModel.DataAnnotations.Schema;

namespace LW2.Model.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("type")]
        public required EquipmentType Type { get; set; }
        [Column("production_area")]
        public required ProductionArea ProductionArea { get; set; }
    }
}
