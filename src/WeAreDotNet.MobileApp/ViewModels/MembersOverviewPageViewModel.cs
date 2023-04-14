using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class MembersOverviewPageViewModel : BaseViewModel
{
    private const int loadingIncrementCount = 12;
    private int currentSkip = 0;

    [ObservableProperty]
    private ObservableCollection<Profile> members = new();

    public MembersOverviewPageViewModel(WeAreDotNetService weAreDotNetService)
        : base(weAreDotNetService)
    {
    }

    [RelayCommand]
    private async Task MemberSelectedAsync(string nickname)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "nickname", nickname }
        };

        await Shell.Current.GoToAsync($"profile", navigationParameter);
    }

    [RelayCommand]
    private async Task LoadMoreMembersAsync()
    {
        currentSkip += loadingIncrementCount;

        var remoteMembers = await weAreDotNetService.GetMembers(currentSkip,
            loadingIncrementCount);

        foreach (var member in remoteMembers)
        {
            Members.Add(member);
        }
    }

    public async Task LoadMembers()
    {
        // TODO we probably want some kind of expiration or force refresh
        if (Members.Count > 0)
        {
            return;
        }

        var remoteMembers = await weAreDotNetService.GetMembers(currentSkip,
            loadingIncrementCount);

        Members.Clear();

        foreach (var member in remoteMembers)
        {
            Members.Add(member);
        }
    }
}
