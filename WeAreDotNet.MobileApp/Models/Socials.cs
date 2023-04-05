using System;
using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class Socials
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("youtube")]
    public string Youtube { get; set; }

    [JsonPropertyName("linkedin")]
    public string Linkedin { get; set; }

    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("github")]
    public string Github { get; set; }

    [JsonPropertyName("linktree")]
    public string Linktree { get; set; }

    [JsonPropertyName("blog")]
    public string Blog { get; set; }

    [JsonPropertyName("mastodon")]
    public string Mastodon { get; set; }

    [JsonPropertyName("mvp")]
    public string Mvp { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("sessionize")]
    public string Sessionize { get; set; }
}
