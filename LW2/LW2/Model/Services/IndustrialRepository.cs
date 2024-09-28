using LW2.Model.Entities;
using LW2.Model.Interfaces;

namespace LW2.Model.Services
{
    public class IndustrialRepository : IIndustrialRepository
    {
        #region Employees
        public async Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }
        public async Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddEmployee(Employee employee)
        {
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
            throw new NotImplementedException();
        }
        public async Task<ProductionArea> GetProductionArea(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddProductionArea(ProductionArea area)
        {
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
            throw new NotImplementedException();
        }
        public async Task<EquipmentType> GetEquipmentType(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddEquipmentType(EquipmentType type)
        {
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
            throw new NotImplementedException();
        }
        public async Task<Equipment> GetEquipment(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddEquipment(Equipment eq)
        {
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
            throw new NotImplementedException();
        }
        public async Task<Inspection> GetInspection(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddInspection(Inspection inspection)
        {
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
            throw new NotImplementedException();
        }
        public async Task<Failure> GetFailure(int id)
        {
            throw new NotImplementedException();
        }
        public async Task AddFailure(Failure inspection)
        {
        }
        public async Task UpdateFailure(Failure inspection)
        {
        }
        public async Task DeleteFailure(int id)
        {
        }

        public Task<List<Failure>> GetFailures(ProductionArea area)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inspection>> GetInspections(int equipmentId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
