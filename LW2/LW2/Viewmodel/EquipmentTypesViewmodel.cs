using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
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
        private ObservableCollection<EquipmentType> _types = [];

        [ObservableProperty]
        private string _newTypeName = string.Empty;

        [RelayCommand]
        public async Task Delete(EquipmentType area)
        {
            await _industrialRepository.DeleteEquipmentType(area.Id);
            Types.Remove(area);
        }

        [RelayCommand]
        public async Task Add()
        {
            var newArea = new EquipmentType()
            {
                Name = NewTypeName
            };

            newArea.Id = await _industrialRepository.AddEquipmentType(newArea);
            
            Types.Add(newArea);
        }

        [RelayCommand]
        public async Task Update(EquipmentType area)
        {
            await _industrialRepository.UpdateEquipmentType(area);
        }

        public override async Task OnAppearing()
        {
            Types = [.. await _industrialRepository.GetEquipmentTypes()];
        }
    }
}
