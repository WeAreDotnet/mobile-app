﻿using System.Text.Json.Serialization;

namespace WeAreDotNet.MobileApp.Models;

public class LandingPageFeed
{
    [JsonPropertyName("feedEntriesTop9")]
    public List<FeedEntry> FeedEntriesTop9 { get; set; }

    [JsonPropertyName("feedEntries")]
    public List<FeedEntry> FeedEntries { get; set; }

    [JsonPropertyName("sponsoredFeedEntries")]
    public List<FeedEntry> SponsoredFeedEntries { get; set; }
}
