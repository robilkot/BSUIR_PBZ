using LW2.Model.Entities;
using LW2.Viewmodel;

namespace LW2.View;

public partial class ProductionAreasTab : ContentPage
{
    private readonly ProductionAreasViewmodel _viewmodel;
    public ProductionAreasTab(ProductionAreasViewmodel vm)
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

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        ForceUpdateContext(grid);

        nameEntry.IsVisible = true;
        nameLabel.IsVisible = false;

        numberEntry.IsVisible = true;
        numberLabel.IsVisible = false;

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

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        nameEntry.IsVisible = false;
        nameLabel.IsVisible = true;

        numberEntry.IsVisible = false;
        numberLabel.IsVisible = true;

        saveButton.IsVisible = false;
        editButton.IsVisible = true;

        ForceUpdateContext(grid);

        await _viewmodel.UpdateCommand.ExecuteAsync(grid.BindingContext as ProductionArea);
    }

    private static void ForceUpdateContext(Element element)
    {
        var ctx = element.BindingContext;
        element.BindingContext = null;
        element.BindingContext = ctx;
    }
}