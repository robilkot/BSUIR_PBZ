using LW2.Model.Entities;
using LW2.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LW2.Model.Services
{
    public class IndustrialRepository : IIndustrialRepository
    {
        private readonly IndustrialDbContext _dbContext;
        public IndustrialRepository(IndustrialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Employees
        public async Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }
        public async Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateEmployee(Employee employee)
        {
        }
        public async Task DeleteEmployee(int id)
        {
        }
        #endregion

        #region Production Areas
        public async Task<List<ProductionArea>> GetProductionAreas()
        {
            var areas = _dbContext.Productionareas;

            return await areas.ToListAsync();
        }
        public async Task<ProductionArea> GetProductionArea(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddProductionArea(ProductionArea area)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateProductionArea(ProductionArea area)
        {
        }
        public async Task DeleteProductionArea(int id)
        {
        }
        #endregion

        #region Equipment types
        public async Task<List<EquipmentType>> GetEquipmentTypes()
        {
            var types = _dbContext.Equipmenttypes;

            return await types.ToListAsync();
        }
        public async Task<EquipmentType> GetEquipmentType(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddEquipmentType(EquipmentType type)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateEquipmentType(EquipmentType type)
        {
        }
        public async Task DeleteEquipmentType(int id)
        {
        }
        #endregion

        #region Equipment
        public async Task<List<Equipment>> GetEquipment()
        {
            var equipment = _dbContext.Equipment.Include(e => e.TypeNavigation);

            return await equipment.ToListAsync();
        }
        public async Task<Equipment> GetEquipment(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddEquipment(Equipment eq)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateEquipment(Equipment eq)
        {
        }
        public async Task DeleteEquipment(int id)
        {
        }
        #endregion

        #region Inspections
        public async Task<List<Inspection>> GetInspections()
        {
            var inspections = _dbContext.Inspections;

            return await inspections.ToListAsync();
        }
        public async Task<Inspection> GetInspection(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddInspection(Inspection inspection)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateInspection(Inspection inspection)
        {
        }
        public async Task DeleteInspection(int id)
        {
        }
        #endregion

        #region Failures
        public async Task<List<Failure>> GetFailures()
        {
            var failures = _dbContext.Failures;

            return await failures.ToListAsync();
        }
        public async Task<Failure> GetFailure(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddFailure(Failure inspection)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateFailure(Failure inspection)
        {
        }
        public async Task DeleteFailure(int id)
        {
        }
        #endregion

        #region Special queries
        // todo
        public async Task<List<Failure>> GetFailures(ProductionArea area)
        {
            var failures = _dbContext.Failures
                .Include(f => f.Equipment)
                .ThenInclude(e => e.TypeNavigation);

            return await failures.ToListAsync();
        }

        // todo
        public async Task<List<Inspection>> GetInspections(int equipmentId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
