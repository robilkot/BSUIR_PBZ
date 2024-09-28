using System.ComponentModel.DataAnnotations.Schema;

namespace LW2.Model.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Column("personnel_number")]
        public required string PersonnelNumber {  get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("position")]
        public required string Position { get; set; }
    }
}
