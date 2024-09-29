﻿using LW2.Model.Entities;
using LW2.Model.Interfaces;

namespace LW2.Model.Services
{
    public class MockIndustrialRepository : IIndustrialRepository
    {
        private static readonly List<ProductionArea> s_areas = [
            new() {Name = "Area 1", Number = "A-001", Id = 1 },
            new() {Name = "Area 2", Number = "A-002", Id = 2 },
            new() {Name = "Area 3", Number = "A-003", Id = 3 },
            new() {Name = "Area 4", Number = "A-004", Id = 4 },
            new() {Name = "Area 5", Number = "A-005", Id = 5 },
            new() {Name = "Area 6", Number = "A-006", Id = 6 },
            new() {Name = "Area 51", Number = "A-051", Id = 7 }
            ];

        private static readonly List<EquipmentType> s_equipmentTypes = [
            new() {Name = "Gas", Id = 1 },
            new() {Name = "Water", Id = 2 },
            new() {Name = "Fire", Id = 3 },
            new() {Name = "Pressure", Id = 4 },
            new() {Name = "GasWaterPressure", Id = 5 },
            new() {Name = "WaterFire", Id = 6 },
            ];

        private static readonly List<Employee> s_employees = [
            new() {Id = 1, Name = "Tim", PersonnelNumber = "E-001", Position = "Sr. Engineer" },
            new() {Id = 2, Name = "Alexiy", PersonnelNumber = "E-002", Position = "Engineer" },
            new() {Id = 3, Name = "Mihail Sadovskiy", PersonnelNumber = "E-003", Position = "Sr. Lecturer" },
            new() {Id = 4, Name = "Shaver", PersonnelNumber = "E-004", Position = "Engineer" },
            new() {Id = 5, Name = "Gus", PersonnelNumber = "E-005", Position = "Lawyer" },
            new() {Id = 6, Name = "Walter", PersonnelNumber = "E-006", Position = "Cook" },
            ];

        private static readonly List<Equipment> s_equipment = [
            new() { Id = 1, Number = "100001", Name = "Stove", Type = 3, TypeNavigation = s_equipmentTypes.First(t => t.Id == 3), ProductionArea = 1, ProductionAreaNavigation = s_areas.First(a => a.Id == 1) },
            new() { Id = 2, Number = "100002", Name = "Oven", Type = 3, TypeNavigation = s_equipmentTypes.First(t => t.Id == 3), ProductionArea = 2, ProductionAreaNavigation = s_areas.First(a => a.Id == 2)  },
            new() { Id = 3, Number = "100003", Name = "Press", Type = 4, TypeNavigation = s_equipmentTypes.First(t => t.Id == 4), ProductionArea = 2, ProductionAreaNavigation = s_areas.First(a => a.Id == 2)  },
            new() { Id = 4, Number = "100004", Name = "Roller", Type = 5, TypeNavigation = s_equipmentTypes.First(t => t.Id == 5), ProductionArea = 7, ProductionAreaNavigation = s_areas.First(a => a.Id == 7)  },
            ];

        #region Employees
        public Task<List<Employee>> GetEmployees()
        {
            return Task.FromResult<List<Employee>>([.. s_employees]);
        }
        public async Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddEmployee(Employee employee)
        {
            int id = s_employees.Max(a => a.Id) + 1;

            employee.Id = id;

            s_employees.Add(employee);

            return Task.FromResult(id);
        }
        public Task UpdateEmployee(Employee employee)
        {
            _ = DeleteEmployee(employee.Id);
            _ = AddEmployee(employee);

            return Task.CompletedTask;
        }
        public Task DeleteEmployee(int id)
        {
            var area = s_employees.FirstOrDefault(a => a.Id == id);

            if (area is not null)
            {
                s_employees.Remove(area);
            }

            return Task.CompletedTask;
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
        public Task<int> AddProductionArea(ProductionArea area)
        {
            int id = s_areas.Max(a => a.Id) + 1;

            area.Id = id;

            s_areas.Add(area);

            return Task.FromResult(id);
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

            if (area is not null)
            {
                s_areas.Remove(area);
            }

            return Task.CompletedTask;
        }
        #endregion

        #region Equipment types
        public Task<List<EquipmentType>> GetEquipmentTypes()
        {
            return Task.FromResult<List<EquipmentType>>([.. s_equipmentTypes]);
        }
        public async Task<EquipmentType> GetEquipmentType(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddEquipmentType(EquipmentType type)
        {
            int id = s_equipmentTypes.Max(a => a.Id) + 1;

            type.Id = id;

            s_equipmentTypes.Add(type);

            return Task.FromResult(id);
        }
        public Task UpdateEquipmentType(EquipmentType type)
        {
            _ = DeleteEquipmentType(type.Id);
            _ = AddEquipmentType(type);

            return Task.CompletedTask;
        }
        public Task DeleteEquipmentType(int id)
        {
            var type = s_equipmentTypes.FirstOrDefault(a => a.Id == id);

            if (type is not null)
            {
                s_equipmentTypes.Remove(type);
            }

            return Task.CompletedTask;
        }
        #endregion

        #region Equipment
        public Task<List<Equipment>> GetEquipment()
        {
            return Task.FromResult<List<Equipment>>([.. s_equipment]);
        }
        public async Task<Equipment> GetEquipment(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddEquipment(Equipment eq)
        {
            int id = s_equipment.Max(a => a.Id) + 1;

            eq.Id = id;

            s_equipment.Add(eq);

            return Task.FromResult(id);
        }
        public Task UpdateEquipment(Equipment eq)
        {
            _ = DeleteEquipment(eq.Id);
            _ = AddEquipment(eq);

            return Task.CompletedTask;
        }
        public Task DeleteEquipment(int id)
        {
            var type = s_equipment.FirstOrDefault(a => a.Id == id);

            if (type is not null)
            {
                s_equipment.Remove(type);
            }

            return Task.CompletedTask;
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
    }
}
