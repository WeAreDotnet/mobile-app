using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly WeAreDotNetService weAreDotNetService;

    [ObservableProperty]
    private ObservableCollection<FeedEntry> feedItems = new();

    [ObservableProperty]
    private FeedEntry selectedFeedItem;

    [RelayCommand]
    private async Task FeedItemSelectedAsync()
    {
        if (string.IsNullOrWhiteSpace(SelectedFeedItem?.Url))
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

        await Browser.Default.OpenAsync(SelectedFeedItem.Url,
            browserOptions);

        SelectedFeedItem = null;
    }

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
