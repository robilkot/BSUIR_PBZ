using CommunityToolkit.Mvvm.ComponentModel;

namespace LW2.Viewmodel
{
    public class BaseViewmodel : ObservableObject
    {
        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }
    }
}
