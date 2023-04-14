using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class MembersOverviewPageViewModel : BaseViewModel
{
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

    public async Task LoadMembers()
    {
        var remoteMembers = await weAreDotNetService.GetMembers(0, 12);

        Members.Clear();

        foreach (var member in remoteMembers)
        {
            Members.Add(member);
        }
    }
}
