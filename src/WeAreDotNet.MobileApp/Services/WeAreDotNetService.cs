using System.Text.Json;
using WeAreDotNet.MobileApp.Models;

namespace WeAreDotNet.MobileApp.Services;

public class WeAreDotNetService
{
    private readonly HttpClient httpClient = new();

    public async Task<LandingPageFeed> GetLandingPageFeed()
    {
        var result = await httpClient.GetStreamAsync("https://api.wearedotnet.io/feeds/topRecent_new");

        return await JsonSerializer.DeserializeAsync<LandingPageFeed>(result);
    }

    public async Task<LandingData> GetLandingData()
    {
        var result = await httpClient.GetStreamAsync("https://api.wearedotnet.io/getLandingData");

        return await JsonSerializer.DeserializeAsync<LandingData>(result);
    }

    public async Task<Creator> GetProfile(string nickname)
    {
        var result = await httpClient.GetStreamAsync($"https://api.wearedotnet.io/creator/{nickname}");

        return await JsonSerializer.DeserializeAsync<Creator>(result);
    }
}
