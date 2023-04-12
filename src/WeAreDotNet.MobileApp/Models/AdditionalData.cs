using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class AdditionalData
{
    [JsonPropertyName("ghstar")]
    public Uri GitHubStarUrl { get; set; }

    public bool IsGitHubStar =>
        string.IsNullOrWhiteSpace(GitHubStarUrl?.ToString());

    [JsonPropertyName("xamarin")]
    public bool IsPlanetXamarinMember { get; set; }

    [JsonPropertyName("msstaff")]
    public bool IsMicrosoftEmployee { get; set; }

    [JsonPropertyName("womanofdotnet")]
    public bool IsWomanOfDotNetMember { get; set; }
}
