using LW2.Model.Entities;
using LW2.Model.Interfaces;

namespace LW2.Model.Services
{
    public class MockIndustrialRepository : IIndustrialRepository
    {
        private static List<ProductionArea> s_areas = [
            new() {Name = "Area 1", Number = "A-001", Id = 1 },
            new() {Name = "Area 2", Number = "A-002", Id = 2 },
            new() {Name = "Area 51", Number = "A-051", Id = 3 }
            ];

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
        public Task<List<ProductionArea>> GetProductionAreas()
        {
            return Task.FromResult<List<ProductionArea>>([.. s_areas]);
        }
        public async Task<ProductionArea> GetProductionArea(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddProductionArea(ProductionArea area)
        {
            int id = s_areas.Max(a => a.Id) + 1;
            
            area.Id = id;

            s_areas.Add(area);

            return Task.CompletedTask;
        }
        public Task UpdateProductionArea(ProductionArea area)
        {
            _ = DeleteProductionArea(area.Id);
            _ = AddProductionArea(area);

            return Task.CompletedTask;
        }
        public Task DeleteProductionArea(int id)
        {
            var area = s_areas.FirstOrDefault(a => a.Id == id);

            if(area is not null)
            {
                s_areas.Remove(area);
            }

            return Task.CompletedTask;
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
        // дата формирования отчета, инвентарный номер, название, тип оборудования, результат осмотра.
        public async Task<List<Inspection>> GetInspections(int equipmentId)
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
        // дата, список (название оборудования, тип оборудования, название участка, причина отказа, дата отказа)
        public async Task<List<Failure>> GetFailures(ProductionArea area)
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
        #endregion
    }
}
