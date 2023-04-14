using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    private async Task OpenSocialAsync(string socialUrl)
    {
        // TODO mostly duplicate with MainPage, refactor
        if (string.IsNullOrWhiteSpace(socialUrl))
        {
            return;
        }

        BrowserLaunchOptions browserOptions = new()
        {
            LaunchMode = BrowserLaunchMode.SystemPreferred,
        };

        if (Application.Current.Resources.TryGetValue("Primary", out var colorvalue))
        {
            // TODO not hardcode to white
            browserOptions.PreferredControlColor = Colors.White;
            browserOptions.PreferredToolbarColor = (Color)colorvalue;
        }

        await Browser.Default.OpenAsync(socialUrl,
            browserOptions);
    }
}
