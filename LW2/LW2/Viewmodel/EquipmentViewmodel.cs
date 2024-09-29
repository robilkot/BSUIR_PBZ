using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class EquipmentViewmodel : BaseViewmodel
    {
        private readonly IIndustrialRepository _industrialRepository;
        public EquipmentViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;
        }

        [ObservableProperty]
        private ObservableCollection<Equipment> _equipment = [];

        [ObservableProperty]
        private string _newTypeName = string.Empty;

        [RelayCommand]
        public async Task Delete(Equipment area)
        {
            await _industrialRepository.DeleteEquipmentType(area.Id);
            Equipment.Remove(area);
        }

        [RelayCommand]
        public async Task Add()
        {
            // todo
            var newArea = new Equipment()
            {
                Name = NewTypeName
            };

            newArea.Id = await _industrialRepository.AddEquipment(newArea);
            
            Equipment.Add(newArea);
        }

        [RelayCommand]
        public async Task Update(Equipment area)
        {
            await _industrialRepository.UpdateEquipment(area);
        }

        public override async Task OnAppearing()
        {
            Equipment = [.. await _industrialRepository.GetEquipment()];
        }
    }
}
