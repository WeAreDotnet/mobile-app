using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels
{
    public partial class CreatorsPageViewModel : BaseViewModel
    {
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

        public async Task LoadRecentJoins()
        {
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
        }
    }
}
