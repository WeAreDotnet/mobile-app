using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public partial class User
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    [JsonPropertyName("picture")]
    public Uri Picture { get; set; }

    [JsonPropertyName("socials")]
    public Socials Socials { get; set; }
}
