using LW2.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LW2.Model.Services
{
    public class IndustrialDbContext : DbContext
    {
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<ProductionArea> ProductionAreas { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Failure> Failures { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration();
        }
    }
}
