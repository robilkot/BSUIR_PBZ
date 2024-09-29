using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    // todo recepient for types and areas changed event
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

        [ObservableProperty]
        private List<EquipmentType> _types = [];

        [ObservableProperty]
        private List<ProductionArea> _areas = [];

        [RelayCommand]
        public async Task Delete(Equipment eq)
        {
            await _industrialRepository.DeleteEquipment(eq.Id);
            Equipment.Remove(eq);
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
        public async Task Update(Equipment eq)
        {
            await _industrialRepository.UpdateEquipment(eq);
        }

        public override async Task OnAppearing()
        {
            var equ = Task.Run(async () =>
            {
                Equipment = [.. await _industrialRepository.GetEquipment()];
            });
            var types = Task.Run(async () =>
            {
                Types = [.. await _industrialRepository.GetEquipmentTypes()];
            });
            var areas = Task.Run(async () =>
            {
                Areas = [.. await _industrialRepository.GetProductionAreas()];
            });

            await Task.WhenAll(equ, types, areas);
        }
    }
}
