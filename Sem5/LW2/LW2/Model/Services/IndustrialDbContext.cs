using Microsoft.EntityFrameworkCore;

namespace LW2.Model.Entities;

public partial class IndustrialDbContext : DbContext
{
    public IndustrialDbContext()
    {
    }
    public IndustrialDbContext(DbContextOptions<IndustrialDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentType> Equipmenttypes { get; set; }

    public virtual DbSet<Failure> Failures { get; set; }

    public virtual DbSet<Inspection> Inspections { get; set; }

    public virtual DbSet<ProductionArea> Productionareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PersonnelNumber)
                .HasMaxLength(50)
                .HasColumnName("personnel_number");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.ProductionArea, "production_area");

            entity.HasIndex(e => e.Type, "type");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            entity.Property(e => e.ProductionArea).HasColumnName("production_area");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.ProductionAreaNavigation).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.ProductionArea)
                .HasConstraintName("equipment_ibfk_2");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("equipment_ibfk_1");
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipmenttypes");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Failure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("failures");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.HasIndex(e => e.LastInspectingEmployeeId, "last_inspecting_employee_id");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(255)
                .HasColumnName("failure_reason");
            entity.Property(e => e.LastInspectingEmployeeId).HasColumnName("last_inspecting_employee_id");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Failures)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("failures_ibfk_2");

            entity.HasOne(d => d.LastInspectingEmployee).WithMany(p => p.Failures)
                .HasForeignKey(d => d.LastInspectingEmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("failures_ibfk_1");
        });

        modelBuilder.Entity<Inspection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inspections");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(255)
                .HasColumnName("failure_reason");
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .HasColumnName("result");

            entity.HasOne(d => d.Employee).WithMany(p => p.Inspections)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("inspections_ibfk_1");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Inspections)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("inspections_ibfk_2");
        });

        modelBuilder.Entity<ProductionArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productionareas");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
