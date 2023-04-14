using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels
{
    public partial class CreatorsPageViewModel : BaseViewModel
    {
        private DateTime lastUpdate = DateTime.MinValue;

        [ObservableProperty]
        private int creatorCount;

        [ObservableProperty]
        private int userCount;

        [ObservableProperty]
        private ObservableCollection<Creator> recentCreators = new();

        [ObservableProperty]
        private ObservableCollection<User> recentUsers = new();

        public CreatorsPageViewModel(WeAreDotNetService weAreDotNetService)
            : base(weAreDotNetService)
        {

        }

        public async Task LoadRecentJoins(bool force = false)
        {
            if (!force && DateTime.Now.Subtract(lastUpdate).TotalMinutes <= 5)
            {
                // TODO maybe do some better caching etc.
                return;
            }

            var landingData = await weAreDotNetService.GetLandingData();

            CreatorCount = landingData.CreatorCount;
            UserCount = landingData.UserCount;

            RecentCreators.Clear();

            foreach (var creator in landingData.RecentCreators)
            {
                RecentCreators.Add(creator);
            }

            RecentUsers.Clear();

            foreach (var user in landingData.RecentJoins)
            {
                RecentUsers.Add(user);
            }

            lastUpdate = DateTime.Now;
        }

        [RelayCommand]
        private async Task ShowProfileAsync(string nickname)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "nickname", nickname }
            };

            await Shell.Current.GoToAsync($"profile", navigationParameter);
        }

        [RelayCommand]
        private async Task ShowMembersAsync()
        {
            await Shell.Current.GoToAsync($"members");
        }

        [RelayCommand]
        private async Task ShowCreatorsAsync()
        {
            await Shell.Current.GoToAsync($"creators");
        }
    }
}
