using CommunityToolkit.Mvvm.ComponentModel;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class ProfilePageViewModel : BaseViewModel
{
    [ObservableProperty]
    private Profile userProfile;

    public ProfilePageViewModel(WeAreDotNetService weAreDotNetService)
        : base (weAreDotNetService)
    {
    }

    public async Task LoadProfile(string nickname)
    {
        UserProfile = await weAreDotNetService.GetProfile(nickname);
    }
}
