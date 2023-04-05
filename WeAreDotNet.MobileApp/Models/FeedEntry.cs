using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class FeedEntry
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("searchScore")]
    public double SearchScore { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("previewImage")]
    public string PreviewImage { get; set; }

    [JsonPropertyName("datePublished")]
    public DateTime DatePublished { get; set; }

    [JsonPropertyName("datePublishedFormatted")]
    public string DatePublishedFormatted { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    [JsonPropertyName("picture")]
    public string Picture { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("likes")]
    public int Likes { get; set; }

    [JsonPropertyName("socials")]
    public Socials Socials { get; set; }
}
