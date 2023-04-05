using System.Collections.ObjectModel;
using System.ComponentModel;
using WeAreDotNet.MobileApp.Models;
using WeAreDotNet.MobileApp.Services;

namespace WeAreDotNet.MobileApp.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly WeAreDotNetService weAreDotNetService;

    public ObservableCollection<FeedEntry> FeedItems { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;

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

        PropertyChanged.Invoke(this, new(nameof(FeedItems)));
    }
}
