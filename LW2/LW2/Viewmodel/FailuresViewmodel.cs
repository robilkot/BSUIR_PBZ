using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class FailuresViewmodel : BaseViewmodel, IRecipient<EmployeesChangedMessage>, IRecipient<EquipmentChangedMessage>
    {
        private readonly IIndustrialRepository _industrialRepository;
        public DateTime Now => DateTime.Now;
        public FailuresViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;

            WeakReferenceMessenger.Default.Register<EmployeesChangedMessage>(this);
            WeakReferenceMessenger.Default.Register<EquipmentChangedMessage>(this);
        }

        [ObservableProperty]
        private ObservableCollection<Failure>? _failures = null;

        [ObservableProperty]
        private List<Equipment>? _equipment = null;

        [ObservableProperty]
        private string _newFailureReason = string.Empty;

        [ObservableProperty]
        private Equipment? _newEquipment = null;

        [RelayCommand]
        public async Task Delete(Failure ins)
        {
            await _industrialRepository.DeleteFailure(ins.Id);
            Failures!.Remove(ins);
        }

        [RelayCommand]
        public async Task Add()
        {
            // todo procedure for adding failure
            // = await _industrialRepository.AddFailure();

            //Failures!.Add(newInspection);
        }

        [RelayCommand]
        public async Task Update(Failure fail)
        {
            // todo procedure for getting new one
            //await _industrialRepository.UpdateFailure(fail);
        }

        public override async Task OnAppearing()
        {
            var inspections = Task.Run(async () =>
            {
                if(Failures is null)
                {
                    await UpdateFailures();
                }
            });
            var equ = Task.Run(async () =>
            {
                if (Equipment is null)
                {
                    await UpdateEquipment();
                }
            });

            await Task.WhenAll(inspections, equ);
        }

        private async Task UpdateEquipment()
        {
            Equipment = [.. await _industrialRepository.GetEquipment()];
            NewEquipment = Equipment.FirstOrDefault();
        }
        private async Task UpdateFailures()
        {
            Failures = [.. await _industrialRepository.GetFailures()];
        }

        public async void Receive(EquipmentChangedMessage message) => await UpdateEquipment();
        public async void Receive(EmployeesChangedMessage message) => await UpdateFailures(); // because employee may have become null in failures
    }
}