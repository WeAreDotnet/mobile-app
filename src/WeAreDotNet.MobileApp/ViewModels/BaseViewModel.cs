using CommunityToolkit.Mvvm.ComponentModel;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public class BaseViewModel : ObservableObject
{
    protected readonly WeAreDotNetService weAreDotNetService;

    public BaseViewModel(WeAreDotNetService weAreDotNetService)
    {
        this.weAreDotNetService = weAreDotNetService;
    }
}
