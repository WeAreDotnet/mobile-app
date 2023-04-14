using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class CreatorsOverviewPageViewModel : BaseViewModel
{
    private const int loadingIncrementCount = 12;
    private int currentSkip = 0;

    [ObservableProperty]
    private ObservableCollection<Profile> creators = new();

    public CreatorsOverviewPageViewModel(WeAreDotNetService weAreDotNetService)
        : base (weAreDotNetService)
    {
    }

    [RelayCommand]
    private async Task CreatorSelectedAsync(string nickname)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "nickname", nickname }
        };

        await Shell.Current.GoToAsync($"profile", navigationParameter);
    }

    [RelayCommand]
    private async Task LoadMoreCreatorsAsync()
    {
        currentSkip += loadingIncrementCount;

        var remoteCreators = await weAreDotNetService.GetCreators(currentSkip,
            loadingIncrementCount);

        foreach (var member in remoteCreators)
        {
            Creators.Add(member);
        }
    }

    public async Task LoadCreators()
    {
        // TODO we probably want some kind of expiration or force refresh
        if (Creators.Count > 0)
        {
            return;
        }

        var remoteCreators = await weAreDotNetService.GetCreators(currentSkip,
            loadingIncrementCount);

        Creators.Clear();

        foreach (var member in remoteCreators)
        {
            Creators.Add(member);
        }
    }
}
