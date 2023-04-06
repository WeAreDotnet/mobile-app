using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public partial class Channel
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }
}
