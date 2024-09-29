using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class EmployeesViewmodel : BaseViewmodel
    {
        private readonly IIndustrialRepository _industrialRepository;
        public EmployeesViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;
        }

        [ObservableProperty]
        private ObservableCollection<Employee>? _employees = null;

        [ObservableProperty]
        private string _newEmployeeName = string.Empty;

        [ObservableProperty]
        private string _newEmployeePersonellNumber = string.Empty;

        [ObservableProperty]
        private string _newEmployeePosition = string.Empty;

        [RelayCommand]
        public async Task Delete(Employee area)
        {
            await _industrialRepository.DeleteProductionArea(area.Id);
            Employees!.Remove(area);

            WeakReferenceMessenger.Default.Send(new EmployeesChangedMessage());
        }

        [RelayCommand]
        public async Task Add()
        {
            var newArea = new Employee()
            {
                Name = NewEmployeeName,
                PersonnelNumber = NewEmployeePersonellNumber,
                Position = NewEmployeePosition,
            };

            newArea.Id = await _industrialRepository.AddEmployee(newArea);

            Employees!.Add(newArea);

            WeakReferenceMessenger.Default.Send(new EmployeesChangedMessage());
        }

        [RelayCommand]
        public async Task Update(Employee area)
        {
            await _industrialRepository.UpdateEmployee(area);

            WeakReferenceMessenger.Default.Send(new EmployeesChangedMessage());
        }

        public override async Task OnAppearing()
        {
            Employees ??= [.. await _industrialRepository.GetEmployees()];
        }
    }
}
