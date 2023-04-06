using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class LandingData
{
    [JsonPropertyName("randomAvatars")]
    public object RandomAvatars { get; set; }

    [JsonPropertyName("recentJoins")]
    public List<User> RecentJoins { get; set; }

    [JsonPropertyName("recentCreators")]
    public List<Creator> RecentCreators { get; set; }

    [JsonPropertyName("userCount")]
    public int UserCount { get; set; }

    [JsonPropertyName("creatorCount")]
    public int CreatorCount { get; set; }
}
