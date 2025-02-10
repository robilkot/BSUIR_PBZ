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
        public FailuresViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;

            WeakReferenceMessenger.Default.Register<EmployeesChangedMessage>(this);
            WeakReferenceMessenger.Default.Register<EquipmentChangedMessage>(this);
        }

        public DateTime Now => DateTime.Now;

        [ObservableProperty]
        private ObservableCollection<Failure>? _failures = null;

        [ObservableProperty]
        private List<Equipment>? _equipment = null;

        [ObservableProperty]
        private string _newFailureReason = string.Empty;

        [ObservableProperty]
        private Equipment? _newEquipment = null;

        // todo selectable date
        [ObservableProperty]
        private DateTime _newDate = DateTime.Now;

        [RelayCommand]
        public async Task Delete(Failure ins)
        {
            await _industrialRepository.DeleteFailure(ins.Id);
            Failures!.Remove(ins);
        }

        [RelayCommand]
        public async Task Add()
        {
            if (NewEquipment is null)
            {
                await Shell.Current.DisplayAlert("Error", "Equipment not specified", "Ok");
                return;
            }

            var newFailure = new Failure()
            {
                Date = NewDate,
                EquipmentId = NewEquipment.Id,
                FailureReason = NewFailureReason,
            };

            await _industrialRepository.AddFailure(newFailure);

            newFailure = await _industrialRepository.GetFailure(newFailure.Id);

            Failures!.Add(newFailure!);
        }

        [RelayCommand]
        public async Task Update(Failure fail)
        {
            // todo: update last inspecting employee?
            await _industrialRepository.UpdateFailure(fail);
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