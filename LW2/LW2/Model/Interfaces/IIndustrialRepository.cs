using LW2.Model.Entities;

namespace LW2.Model.Interfaces
{
    public interface IIndustrialRepository
    {
        Task AddEmployee(Employee employee);
        Task AddEquipment(Equipment eq);
        Task AddEquipmentType(EquipmentType type);
        Task AddFailure(Failure inspection);
        Task AddInspection(Inspection inspection);
        Task AddProductionArea(ProductionArea area);
        Task DeleteEmployee(int id);
        Task DeleteEquipment(int id);
        Task DeleteEquipmentType(int id);
        Task DeleteFailure(int id);
        Task DeleteInspection(int id);
        Task DeleteProductionArea(int id);
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployees();
        Task<List<Equipment>> GetEquipment();
        Task<Equipment> GetEquipment(int id);
        Task<EquipmentType> GetEquipmentType(int id);
        Task<List<EquipmentType>> GetEquipmentTypes();
        Task<Failure> GetFailure(int id);
        Task<List<Failure>> GetFailures();
        Task<List<Failure>> GetFailures(ProductionArea area);
        Task<Inspection> GetInspection(int id);
        Task<List<Inspection>> GetInspections();
        Task<List<Inspection>> GetInspections(int equipmentId);
        Task<ProductionArea> GetProductionArea(int id);
        Task<List<ProductionArea>> GetProductionAreas();
        Task UpdateEmployee(Employee employee);
        Task UpdateEquipment(Equipment eq);
        Task UpdateEquipmentType(EquipmentType type);
        Task UpdateFailure(Failure inspection);
        Task UpdateInspection(Inspection inspection);
        Task UpdateProductionArea(ProductionArea area);
    }
}