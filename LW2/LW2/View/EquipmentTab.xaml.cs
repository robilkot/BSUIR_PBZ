using LW2.Model.Entities;
using LW2.Viewmodel;

namespace LW2.View;

public partial class EquipmentTab : ContentPage
{
    private readonly EquipmentViewmodel _viewmodel;
    public EquipmentTab(EquipmentViewmodel vm)
    {
        InitializeComponent();

        _viewmodel = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewmodel.OnAppearing();
    }

    private void editButton_Pressed(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var grid = (Grid)btn.Parent;

        var nameEntry = (Entry)grid.FindByName("nameEntry");
        var nameLabel = (Label)grid.FindByName("nameLabel");

        var numberEntry = (Entry)grid.FindByName("numberEntry");
        var numberLabel = (Label)grid.FindByName("numberLabel");

        var typePicker = (Picker)grid.FindByName("typePicker");
        var typeLabel = (Label)grid.FindByName("typeLabel");

        var areaPicker = (Picker)grid.FindByName("areaPicker");
        var areaLabel = (Label)grid.FindByName("areaLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        ForceUpdateContext(grid);

        var equipment = (Equipment)grid.BindingContext;

        // todo handle deleting foreign stuff
        var types = (IEnumerable<EquipmentType>)typePicker.ItemsSource;
        typePicker.SelectedItem = types.FirstOrDefault(t => t.Id == equipment.Type);

        var areas = (IEnumerable<ProductionArea>)areaPicker.ItemsSource;
        areaPicker.SelectedItem = areas.FirstOrDefault(t => t.Id == equipment.ProductionArea);

        nameEntry.IsVisible = true;
        nameLabel.IsVisible = false;

        numberEntry.IsVisible = true;
        numberLabel.IsVisible = false;

        typePicker.IsVisible = true;
        typeLabel.IsVisible = false;

        areaPicker.IsVisible = true;
        areaLabel.IsVisible = false;

        saveButton.IsVisible = true;
        editButton.IsVisible = false;
    }

    private async void saveButton_Pressed(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var grid = (Grid)btn.Parent;

        var nameEntry = (Entry)grid.FindByName("nameEntry");
        var nameLabel = (Label)grid.FindByName("nameLabel");

        var numberEntry = (Entry)grid.FindByName("numberEntry");
        var numberLabel = (Label)grid.FindByName("numberLabel");

        var typePicker = (Picker)grid.FindByName("typePicker");
        var typeLabel = (Label)grid.FindByName("typeLabel");

        var areaPicker = (Picker)grid.FindByName("areaPicker");
        var areaLabel = (Label)grid.FindByName("areaLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        nameEntry.IsVisible = false;
        nameLabel.IsVisible = true;

        numberEntry.IsVisible = false;
        numberLabel.IsVisible = true;

        typePicker.IsVisible = false;
        typeLabel.IsVisible = true;

        areaPicker.IsVisible = false;
        areaLabel.IsVisible = true;

        saveButton.IsVisible = false;
        editButton.IsVisible = true;

        var equipment = (Equipment)grid.BindingContext;

        var type = (EquipmentType)typePicker.SelectedItem;
        equipment.Type = type.Id;
        equipment.TypeNavigation = type;

        var area = (ProductionArea)areaPicker.SelectedItem;
        equipment.ProductionArea = area.Id;
        equipment.ProductionAreaNavigation = area;

        ForceUpdateContext(grid);

        await _viewmodel.UpdateCommand.ExecuteAsync(equipment);
    }

    private static void ForceUpdateContext(Element element)
    {
        var ctx = element.BindingContext;
        element.BindingContext = null;
        element.BindingContext = ctx;
    }
}