using System.ComponentModel.DataAnnotations.Schema;

namespace LW2.Model.Entities
{
    public class ProductionArea
    {
        public int Id { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("name")]
        public required string Name { get; set; }
    }
}
