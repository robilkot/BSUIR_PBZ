using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class EquipmentViewmodel : BaseViewmodel, IRecipient<EquipmentTypesChangedMessage>, IRecipient<AreasChangedMessage>
    {
        private readonly IIndustrialRepository _industrialRepository;
        public EquipmentViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;

            WeakReferenceMessenger.Default.Register<EquipmentTypesChangedMessage>(this);
            WeakReferenceMessenger.Default.Register<AreasChangedMessage>(this);
        }

        [ObservableProperty]
        private ObservableCollection<Equipment>? _equipment = null;

        [ObservableProperty]
        private string _newEquName = string.Empty;

        [ObservableProperty]
        private string _newEquNumber = string.Empty;

        [ObservableProperty]
        private EquipmentType? _newEquType;

        [ObservableProperty]
        private ProductionArea? _newEquArea;

        [ObservableProperty]
        private List<EquipmentType>? _types = null;

        [ObservableProperty]
        private List<ProductionArea>? _areas = null;

        [RelayCommand]
        public async Task Delete(Equipment eq)
        {
            await _industrialRepository.DeleteEquipment(eq.Id);
            Equipment!.Remove(eq);
        }

        [RelayCommand]
        public async Task Add()
        {
            if (NewEquType is null)
            {
                await Shell.Current.DisplayAlert("Error", "Equipment type not specified", "Ok");
                return;
            }
            if (NewEquArea is null)
            {
                await Shell.Current.DisplayAlert("Error", "Area not specified", "Ok");
                return;
            }

            var newEquipment = new Equipment()
            {
                Name = NewEquName,
                Number = NewEquNumber,
                Type = NewEquType.Id,
                ProductionArea = NewEquArea.Id,
            };

            newEquipment.Id = await _industrialRepository.AddEquipment(newEquipment);

            newEquipment = await _industrialRepository.GetEquipment(newEquipment.Id);

            Equipment!.Add(newEquipment!);
        }

        [RelayCommand]
        public async Task Update(Equipment eq)
        {
            await _industrialRepository.UpdateEquipment(eq);
        }

        public override async Task OnAppearing()
        {
            var equ = Task.Run(async () =>
            {
                Equipment ??= [.. await _industrialRepository.GetEquipment()];
            });
            var types = Task.Run(async () =>
            {
                if(Types is null)
                {
                    await UpdateEquipmentTypes();
                }
            });
            var areas = Task.Run(async () =>
            {
                if(Areas is null)
                {
                    await UpdateProductionAreas();
                }
            });

            await Task.WhenAll(equ, types, areas);
        }

        public async void Receive(AreasChangedMessage message) => await UpdateProductionAreas();
        public async void Receive(EquipmentTypesChangedMessage message) => await UpdateEquipmentTypes();

        private async Task UpdateProductionAreas()
        {
            Areas = [.. await _industrialRepository.GetProductionAreas()];
            NewEquArea = Areas.FirstOrDefault();
        }
        private async Task UpdateEquipmentTypes()
        {
            Types = [.. await _industrialRepository.GetEquipmentTypes()];
            NewEquType = Types.FirstOrDefault();
        }
    }
}
