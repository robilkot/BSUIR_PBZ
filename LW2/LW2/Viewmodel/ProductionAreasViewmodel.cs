using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Messaging;
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
        private ObservableCollection<ProductionArea>? _areas = null;

        [ObservableProperty]
        private string _newAreaName = string.Empty;

        [ObservableProperty]
        private string _newAreaNumber = string.Empty;

        [RelayCommand]
        public async Task Delete(ProductionArea area)
        {
            await _industrialRepository.DeleteProductionArea(area.Id);
            Areas!.Remove(area);

            WeakReferenceMessenger.Default.Send(new AreasChangedMessage());
        }

        [RelayCommand]
        public async Task Add()
        {
            var newArea = new ProductionArea()
            {
                Name = NewAreaName,
                Number = NewAreaNumber,
            };

            newArea.Id = await _industrialRepository.AddProductionArea(newArea);
            
            Areas!.Add(newArea);

            WeakReferenceMessenger.Default.Send(new AreasChangedMessage());
        }

        [RelayCommand]
        public async Task Update(ProductionArea area)
        {
            await _industrialRepository.UpdateProductionArea(area);

            WeakReferenceMessenger.Default.Send(new AreasChangedMessage());
        }

        public override async Task OnAppearing()
        {
            Areas ??= [.. await _industrialRepository.GetProductionAreas()];
        }
    }
}
