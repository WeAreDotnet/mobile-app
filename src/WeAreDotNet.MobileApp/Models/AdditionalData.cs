using System.Text.Json.Serialization;
using WeAreDotNet.MobileApp.Converters;

namespace WeAreDotNet.MobileApp.Models;

public class AdditionalData
{
    [JsonPropertyName("ghstar")]
    public Uri GitHubStarUrl { get; set; }

    public bool IsGitHubStar =>
        !string.IsNullOrWhiteSpace(GitHubStarUrl?.ToString());

    [JsonPropertyName("xamarin")]
    [JsonConverter(typeof(JsonBoolConverter))]
    public bool IsPlanetXamarinMember { get; set; }

    [JsonPropertyName("msstaff")]
    [JsonConverter(typeof(JsonBoolConverter))]
    public bool IsMicrosoftEmployee { get; set; }

    [JsonPropertyName("womenofdotnet")]
    [JsonConverter(typeof(JsonBoolConverter))]
    public bool IsWomenOfDotNetMember { get; set; }
}
