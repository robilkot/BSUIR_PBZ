using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class EquipmentTypesViewmodel : BaseViewmodel
    {
        private readonly IIndustrialRepository _industrialRepository;
        public EquipmentTypesViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;
        }

        [ObservableProperty]
        private ObservableCollection<EquipmentType>? _types = null;

        [ObservableProperty]
        private string _newTypeName = string.Empty;

        [RelayCommand]
        public async Task Delete(EquipmentType area)
        {
            await _industrialRepository.DeleteEquipmentType(area.Id);
            Types!.Remove(area);

            WeakReferenceMessenger.Default.Send(new EquipmentTypesChangedMessage());
        }

        [RelayCommand]
        public async Task Add()
        {
            var newArea = new EquipmentType()
            {
                Name = NewTypeName
            };

            newArea.Id = await _industrialRepository.AddEquipmentType(newArea);
            
            Types!.Add(newArea);

            WeakReferenceMessenger.Default.Send(new EquipmentTypesChangedMessage());
        }

        [RelayCommand]
        public async Task Update(EquipmentType area)
        {
            await _industrialRepository.UpdateEquipmentType(area);

            WeakReferenceMessenger.Default.Send(new EquipmentTypesChangedMessage());
        }

        public override async Task OnAppearing()
        {
            Types ??= [.. await _industrialRepository.GetEquipmentTypes()];
        }
    }
}
