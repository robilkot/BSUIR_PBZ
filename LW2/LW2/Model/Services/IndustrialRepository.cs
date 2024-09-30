using LW2.Model.Entities;
using LW2.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LW2.Model.Services
{
    public class IndustrialRepository : IIndustrialRepository
    {
        private readonly IDbContextFactory<IndustrialDbContext> _dbContextFactory;
        public IndustrialRepository(IDbContextFactory<IndustrialDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region Employees
        public async Task<List<Employee>> GetEmployees()
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            return await ctx.Employees.ToListAsync();
        }
        public async Task<Employee?> GetEmployee(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            return await ctx.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Employees.AddAsync(employee);
            await ctx.SaveChangesAsync();

            return employee.Id;
        }
        public async Task UpdateEmployee(Employee employee)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            ctx.Update(employee);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var empl = await ctx.Employees.FirstOrDefaultAsync(emp => emp.Id == id);

            if (empl is not null)
            {
                ctx.Remove(empl);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Production Areas
        public async Task<List<ProductionArea>> GetProductionAreas()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Productionareas.ToListAsync();
        }
        
        public async Task<ProductionArea?> GetProductionArea(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Productionareas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> AddProductionArea(ProductionArea area)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Productionareas.AddAsync(area);

            await ctx.SaveChangesAsync();

            return area.Id;
        }
        public async Task UpdateProductionArea(ProductionArea area)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            ctx.Update(area);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteProductionArea(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var empl = await ctx.Productionareas.FirstOrDefaultAsync(emp => emp.Id == id);

            if (empl is not null)
            {
                ctx.Remove(empl);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Equipment types
        public async Task<List<EquipmentType>> GetEquipmentTypes()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Equipmenttypes.ToListAsync();
        }
        public async Task<EquipmentType?> GetEquipmentType(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Equipmenttypes.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> AddEquipmentType(EquipmentType type)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Equipmenttypes.AddAsync(type);

            await ctx.SaveChangesAsync();

            return type.Id;
        }
        public async Task UpdateEquipmentType(EquipmentType type)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            ctx.Update(type);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteEquipmentType(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var type = await ctx.Equipmenttypes.FirstOrDefaultAsync(emp => emp.Id == id);

            if (type is not null)
            {
                ctx.Remove(type);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Equipment
        public async Task<List<Equipment>> GetEquipment()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Equipment
                .Include(e => e.ProductionAreaNavigation)
                .Include(e => e.TypeNavigation)
                .ToListAsync();
        }
        public async Task<Equipment?> GetEquipment(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Equipment
                .Include(e => e.ProductionAreaNavigation)
                .Include(e => e.TypeNavigation)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> AddEquipment(Equipment eq)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Equipment.AddAsync(eq);

            await ctx.SaveChangesAsync();

            return eq.Id;
        }
        public async Task UpdateEquipment(Equipment eq)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            ctx.Update(eq);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteEquipment(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var equ = await ctx.Equipment.FirstOrDefaultAsync(emp => emp.Id == id);

            if (equ is not null)
            {
                ctx.Remove(equ);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Inspections
        public async Task<List<Inspection>> GetInspections()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Inspections
                .Include(i => i.Employee)
                .Include(i => i.Equipment)
                .ToListAsync();
        }
        public async Task<Inspection?> GetInspection(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Inspections
                .Include(i => i.Employee)
                .Include(i=> i.Equipment)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> AddInspection(Inspection inspection)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Inspections.AddAsync(inspection);

            await ctx.SaveChangesAsync();

            return inspection.Id;
        }
        public async Task UpdateInspection(Inspection inspection)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            ctx.Update(inspection);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteInspection(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var insp = await ctx.Inspections.FirstOrDefaultAsync(emp => emp.Id == id);

            if (insp is not null)
            {
                ctx.Remove(insp);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Failures
        public async Task<List<Failure>> GetFailures()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Failures
                .Include(f => f.Equipment)
                .Include(f => f.LastInspectingEmployee)
                .ToListAsync();
        }
        public async Task<Failure?> GetFailure(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Failures
                .Include(f => f.Equipment)
                .Include(f => f.LastInspectingEmployee)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> AddFailure(Failure inspection)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            await ctx.Failures.AddAsync(inspection);

            await ctx.SaveChangesAsync();

            return inspection.Id;
        }
        public async Task UpdateFailure(Failure failure)
        {
            using var ctx = _dbContextFactory.CreateDbContext(); 

            ctx.Update(failure);

            await ctx.SaveChangesAsync();
        }
        public async Task DeleteFailure(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var fail = await ctx.Failures.FirstOrDefaultAsync(emp => emp.Id == id);

            if (fail is not null)
            {
                ctx.Remove(fail);
            }

            await ctx.SaveChangesAsync();
        }
        #endregion

        #region Special queries
        // todo call this somewhere
        public async Task<List<Failure>> GetFailures(ProductionArea area)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Failures
                .Join(ctx.Equipment,
                f => f.EquipmentId,
                e => e.Id,
                (failure, e) => new { failure, e.ProductionArea })
                .Where(t => t.ProductionArea == area.Id)
                .Select(t => t.failure)
                .AsNoTracking()
                .ToListAsync();
        }

        // todo call this somewhere
        public async Task<List<Inspection>> GetInspections(int equipmentId)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Inspections
                .Where(i => i.EquipmentId == equipmentId)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion
    }
}
