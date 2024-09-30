using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class InspectionsViewmodel : BaseViewmodel, IRecipient<EmployeesChangedMessage>, IRecipient<EquipmentChangedMessage>
    {
        private readonly IIndustrialRepository _industrialRepository;
        public DateTime Now => DateTime.Now;
        public InspectionsViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;

            WeakReferenceMessenger.Default.Register<EmployeesChangedMessage>(this);
            WeakReferenceMessenger.Default.Register<EquipmentChangedMessage>(this);
        }

        [ObservableProperty]
        private ObservableCollection<Inspection>? _inspections = null;

        [ObservableProperty]
        private List<Equipment>? _equipment = null;

        [ObservableProperty]
        private List<Employee>? _employees = null;

        [ObservableProperty]
        private string _newResult = string.Empty;

        [ObservableProperty]
        private string _newFailureReason = string.Empty;

        [ObservableProperty]
        private Employee? _newEmployee = null;

        [ObservableProperty]
        private Equipment? _newEquipment = null;

        [RelayCommand]
        public async Task Delete(Inspection ins)
        {
            await _industrialRepository.DeleteInspection(ins.Id);
            Inspections!.Remove(ins);
        }

        [RelayCommand]
        public async Task Add()
        {
            var newInspection = new Inspection()
            {
                Date = Now,
                EmployeeId = NewEmployee.Id,
                EquipmentId = NewEquipment.Id,
                FailureReason = NewFailureReason.Length == 0 ? null : NewFailureReason,
                Result = NewResult,
            };

            newInspection.Id = await _industrialRepository.AddInspection(newInspection);

            newInspection = await _industrialRepository.GetInspection(newInspection.Id);

            Inspections!.Add(newInspection!);
        }

        [RelayCommand]
        public async Task Update(Inspection ins)
        {
            await _industrialRepository.UpdateInspection(ins);
        }

        public override async Task OnAppearing()
        {
            var inspections = Task.Run(async () =>
            {
                if(Inspections is null)
                {
                    await UpdateInspections();
                }
            });
            var equ = Task.Run(async () =>
            {
                if (Equipment is null)
                {
                    await UpdateEquipment();
                }
            });
            var empl = Task.Run(async () =>
            {
                if (Employees is null)
                {
                    await UpdateEmployees();
                }
            });

            await Task.WhenAll(inspections, equ, empl);
        }

        private async Task UpdateInspections()
        {
            Inspections = [.. await _industrialRepository.GetInspections()];
        }
        private async Task UpdateEquipment()
        {
            Equipment = [.. await _industrialRepository.GetEquipment()];
            NewEquipment = Equipment.FirstOrDefault();
        }
        private async Task UpdateEmployees()
        {
            Employees = [.. await _industrialRepository.GetEmployees()];
            NewEmployee = Employees.FirstOrDefault();
        }

        public async void Receive(EquipmentChangedMessage message) => await UpdateEquipment();
        public async void Receive(EmployeesChangedMessage message)
        {
            await UpdateEmployees();
            await UpdateInspections(); // because employees may be deleted and become null in inspections
        }
    }
}