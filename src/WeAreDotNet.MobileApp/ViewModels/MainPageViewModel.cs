using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly WeAreDotNetService weAreDotNetService;

    [ObservableProperty]
    private ObservableCollection<FeedEntry> feedItems = new();

    public MainPageViewModel(WeAreDotNetService weAreDotNetService)
    {
        this.weAreDotNetService = weAreDotNetService;
    }

    public async Task LoadFeedItems()
    {
        var landingPageFeed = await weAreDotNetService.GetLandingPageFeed();

        FeedItems.Clear();

        foreach (var item in landingPageFeed.FeedEntriesTop9)
        {
            FeedItems.Add(item);
        }
    }
}
