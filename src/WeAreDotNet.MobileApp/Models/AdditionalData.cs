using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class AdditionalData
{
    [JsonPropertyName("ghstar")]
    public Uri GitHubStarUrl { get; set; }

    public bool IsGitHubStar => GitHubStarUrl is not null;

    [JsonPropertyName("xamarin")]
    public bool IsPlanetXamarinMember { get; set; }

    [JsonPropertyName("womanofdotnet")]
    public bool IsWomanOfDotNetMember { get; set; }
}
