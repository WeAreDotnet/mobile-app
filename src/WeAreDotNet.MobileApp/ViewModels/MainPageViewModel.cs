using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool isDataRefreshing;

    [ObservableProperty]
    private ObservableCollection<FeedEntry> feedItems = new();

    private DateTime lastUpdate = DateTime.MinValue;

    public MainPageViewModel(WeAreDotNetService weAreDotNetService)
        : base (weAreDotNetService)
    {

    }

    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        await LoadFeedItems(true);
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
    private async Task FeedItemSelectedAsync(FeedEntry entry)
    {
        if (string.IsNullOrWhiteSpace(entry.Url))
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

        await Browser.Default.OpenAsync(entry.Url,
            browserOptions);
    }

    public async Task LoadFeedItems(bool force = false)
    {
        if (!force && DateTime.Now.Subtract(lastUpdate).TotalMinutes <= 5)
        {
            // TODO maybe do some better caching etc.
            return;
        }

        if (!IsDataRefreshing)
        {
            IsDataRefreshing = true;
        }

        var landingPageFeed = await weAreDotNetService.GetLandingPageFeed();

        FeedItems.Clear();

        foreach (var item in landingPageFeed.FeedEntriesTop9)
        {
            FeedItems.Add(item);
        }

        lastUpdate = DateTime.Now;

        IsDataRefreshing = false;
    }
}
