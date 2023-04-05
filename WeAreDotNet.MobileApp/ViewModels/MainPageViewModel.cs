using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using WeAreDotNet.MobileApp.Models;

namespace WeAreDotNet.MobileApp.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<FeedEntry> FeedItems { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;

    public async Task LoadFeedItems()
    {
        HttpClient httpClient = new();

        var result = await httpClient.GetStreamAsync("https://api.wearedotnet.io/feeds/topRecent_new");
        var typedResult = await JsonSerializer.DeserializeAsync<LandingPageFeed>(result);

        FeedItems.Clear();

        foreach (var item in typedResult.FeedEntriesTop9)
        {
            FeedItems.Add(item);
        }

        PropertyChanged.Invoke(this, new(nameof(FeedItems)));
    }
}
