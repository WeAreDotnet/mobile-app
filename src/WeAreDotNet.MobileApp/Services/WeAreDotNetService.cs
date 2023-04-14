using System.Text.Json;
using WeAreDotNet.MobileApp.Models;

namespace WeAreDotNet.MobileApp.Services;

public class WeAreDotNetService
{
    private const string baseUrl = "https://api.wearedotnet.io";
    private readonly HttpClient httpClient = new();

    public WeAreDotNetService()
    {
        httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<LandingPageFeed> GetLandingPageFeed()
    {
        var result = await httpClient.GetStreamAsync("feeds/topRecent_new");

        return await JsonSerializer.DeserializeAsync<LandingPageFeed>(result);
    }

    public async Task<LandingData> GetLandingData()
    {
        var result = await httpClient.GetStreamAsync("getLandingData");

        return await JsonSerializer.DeserializeAsync<LandingData>(result);
    }

    public async Task<Profile> GetProfile(string nickname)
    {
        var result = await httpClient.GetStreamAsync($"creator/{nickname}");

        return await JsonSerializer.DeserializeAsync<Profile>(result);
    }

    public async Task<List<Profile>> GetMembers(int skip = 0, int take = 10)
    {
        var result = await httpClient.GetStreamAsync($"members/find?skip={skip}&take={take}");

        return await JsonSerializer.DeserializeAsync<List<Profile>>(result);
    }

    public async Task<List<Profile>> GetCreators(int skip = 0, int take = 10)
    {
        var result = await httpClient.GetStreamAsync($"creator/search?skip={skip}&take={take}");

        return await JsonSerializer.DeserializeAsync<List<Profile>>(result);
    }
}
