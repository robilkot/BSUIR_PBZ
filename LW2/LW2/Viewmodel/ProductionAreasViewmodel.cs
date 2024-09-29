using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using System.Collections.ObjectModel;

namespace LW2.Viewmodel
{
    public partial class ProductionAreasViewmodel : BaseViewmodel
    {
        private readonly IIndustrialRepository _industrialRepository;
        public ProductionAreasViewmodel(IIndustrialRepository industrialRepository)
        {
            _industrialRepository = industrialRepository;
        }

        [ObservableProperty]
        private ObservableCollection<ProductionArea> _areas = [];

        [ObservableProperty]
        private string _newAreaName = string.Empty;

        [ObservableProperty]
        private string _newAreaNumber = string.Empty;

        [RelayCommand]
        public async Task Delete(ProductionArea area)
        {
            await _industrialRepository.DeleteProductionArea(area.Id);
            Areas.Remove(area);
        }

        [RelayCommand]
        public async Task Add()
        {
            var newArea = new ProductionArea()
            {
                Name = NewAreaName,
                Number = NewAreaNumber,
            };

            await _industrialRepository.AddProductionArea(newArea);
            
            await OnAppearing();
        }

        [RelayCommand]
        public async Task Update(ProductionArea area)
        {
            await _industrialRepository.UpdateProductionArea(area);
        }

        public override async Task OnAppearing()
        {
            Areas = [.. await _industrialRepository.GetProductionAreas()];
        }
    }
}
