using LW2.Model.Entities;
using LW2.Viewmodel;

namespace LW2.View;

public partial class InspectionsTab : ContentPage
{
    private readonly InspectionsViewmodel _viewmodel;
    public InspectionsTab(InspectionsViewmodel vm)
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

        var datePicker = (DatePicker)grid.FindByName("datePicker");
        var dateLabel = (Label)grid.FindByName("dateLabel");

        var resultEntry = (Entry)grid.FindByName("resultEntry");
        var resultLabel = (Label)grid.FindByName("resultLabel");

        var equipmentPicker = (Picker)grid.FindByName("equipmentPicker");
        var equipmentLabel = (Label)grid.FindByName("equipmentLabel");

        var employeePicker = (Picker)grid.FindByName("employeePicker");
        var employeeLabel = (Label)grid.FindByName("employeeLabel");

        var failureReasonEntry = (Entry)grid.FindByName("failureReasonEntry");
        var failureReasonLabel = (Label)grid.FindByName("failureReasonLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        ForceUpdateContext(grid);

        var inspection = (Inspection)grid.BindingContext;

        // todo handle deleting foreign stuff
        var equ = (IEnumerable<Equipment>)equipmentPicker.ItemsSource;
        equipmentPicker.SelectedItem = equ.FirstOrDefault(t => t.Id == inspection.EquipmentId);

        var employees = (IEnumerable<Employee>)employeePicker.ItemsSource;
        employeePicker.SelectedItem = employees.FirstOrDefault(t => t.Id == inspection.EmployeeId);

        datePicker.IsVisible = true;
        dateLabel.IsVisible = false;

        resultEntry.IsVisible = true;
        resultLabel.IsVisible = false;

        equipmentPicker.IsVisible = true;
        equipmentLabel.IsVisible = false;

        employeePicker.IsVisible = true;
        employeeLabel.IsVisible = false;

        failureReasonEntry.IsVisible = true;
        failureReasonLabel.IsVisible = false;

        saveButton.IsVisible = true;
        editButton.IsVisible = false;
    }

    private async void saveButton_Pressed(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var grid = (Grid)btn.Parent;

        var datePicker = (DatePicker)grid.FindByName("datePicker");
        var dateLabel = (Label)grid.FindByName("dateLabel");

        var resultEntry = (Entry)grid.FindByName("resultEntry");
        var resultLabel = (Label)grid.FindByName("resultLabel");

        var equipmentPicker = (Picker)grid.FindByName("equipmentPicker");
        var equipmentLabel = (Label)grid.FindByName("equipmentLabel");

        var employeePicker = (Picker)grid.FindByName("employeePicker");
        var employeeLabel = (Label)grid.FindByName("employeeLabel");

        var failureReasonEntry = (Entry)grid.FindByName("failureReasonEntry");
        var failureReasonLabel = (Label)grid.FindByName("failureReasonLabel");

        var editButton = (Button)grid.FindByName("editButton");
        var saveButton = (Button)grid.FindByName("saveButton");

        datePicker.IsVisible = false;
        dateLabel.IsVisible = true;

        resultEntry.IsVisible = false;
        resultLabel.IsVisible = true;

        equipmentPicker.IsVisible = false;
        equipmentLabel.IsVisible = true;

        employeePicker.IsVisible = false;
        employeeLabel.IsVisible = true;

        failureReasonEntry.IsVisible = false;
        failureReasonLabel.IsVisible = true;

        saveButton.IsVisible = false;
        editButton.IsVisible = true;

        var inspection = (Inspection)grid.BindingContext;

        var equ = (Equipment)equipmentPicker.SelectedItem;
        inspection.EquipmentId = equ.Id;
        inspection.Equipment = equ;

        var empl = (Employee)employeePicker.SelectedItem;
        inspection.EmployeeId = empl.Id;
        inspection.Employee = empl;

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