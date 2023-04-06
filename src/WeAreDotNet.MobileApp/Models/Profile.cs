using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public partial class Profile
{
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    [JsonPropertyName("socials")]
    public Socials Socials { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    [JsonPropertyName("picture")]
    public Uri Picture { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("isMVP")]
    public bool IsMvp { get; set; }

    [JsonPropertyName("isCreator")]
    public bool IsCreator { get; set; }

    [JsonPropertyName("signupDate")]
    public DateTimeOffset SignupDate { get; set; }

    [JsonPropertyName("hasCreatorCard")]
    public bool HasCreatorCard { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("feed")]
    public List<object> Feed { get; set; }

    [JsonPropertyName("channels")]
    public List<Channel> Channels { get; set; }

    [JsonPropertyName("countryName")]
    public object CountryName { get; set; }

    [JsonPropertyName("additionalData")]
    public AdditionalData AdditionalData { get; set; }
}
