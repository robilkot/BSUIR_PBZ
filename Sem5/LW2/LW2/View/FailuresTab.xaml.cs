using LW2.Model.Entities;
using LW2.Viewmodel;

namespace LW2.View;

public partial class FailuresTab : ContentPage
{
    private readonly FailuresViewmodel _viewmodel;
    public FailuresTab(FailuresViewmodel vm)
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

        var equipmentPicker = (Picker)grid.FindByName("equipmentPicker");
        var equipmentLabel = (Label)grid.FindByName("equipmentLabel");

        var failureReasonEntry = (Entry)grid.FindByName("failureReasonEntry");
        var failureReasonLabel = (Label)grid.FindByName("failureReasonLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        ForceUpdateContext(grid);

        var inspection = (Failure)grid.BindingContext;

        var equ = (IEnumerable<Equipment>)equipmentPicker.ItemsSource;
        equipmentPicker.SelectedItem = equ.FirstOrDefault(t => t.Id == inspection.EquipmentId);

        equipmentPicker.IsVisible = true;
        equipmentLabel.IsVisible = false;

        failureReasonEntry.IsVisible = true;
        failureReasonLabel.IsVisible = false;

        saveButton.IsVisible = true;
        editButton.IsVisible = false;
    }

    private async void saveButton_Pressed(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var grid = (Grid)btn.Parent;

        var equipmentPicker = (Picker)grid.FindByName("equipmentPicker");
        var equipmentLabel = (Label)grid.FindByName("equipmentLabel");

        var failureReasonEntry = (Entry)grid.FindByName("failureReasonEntry");
        var failureReasonLabel = (Label)grid.FindByName("failureReasonLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        equipmentPicker.IsVisible = false;
        equipmentLabel.IsVisible = true;

        failureReasonEntry.IsVisible = false;
        failureReasonLabel.IsVisible = true;

        saveButton.IsVisible = false;
        editButton.IsVisible = true;

        var inspection = (Failure)grid.BindingContext;

        var equ = (Equipment)equipmentPicker.SelectedItem;
        inspection.EquipmentId = equ.Id;
        inspection.Equipment = equ;

        ForceUpdateContext(grid);

        await _viewmodel.UpdateCommand.ExecuteAsync(inspection);
    }

    private static void ForceUpdateContext(Element element)
    {
        var ctx = element.BindingContext;
        element.BindingContext = null;
        element.BindingContext = ctx;
    }
}