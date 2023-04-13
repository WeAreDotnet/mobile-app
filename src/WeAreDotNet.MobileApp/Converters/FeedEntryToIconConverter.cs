using System;
using System.Globalization;
using WeAreDotNet.MobileApp.Models;

namespace WeAreDotNet.MobileApp.Converters;

public class FeedEntryToIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var feedEntryType = value as string;

        if (string.IsNullOrWhiteSpace(feedEntryType))
        {
            // TODO What is the gracefall fallback color?
            return ImageSource.FromFile("shape_plus.png");
        }

        return feedEntryType.ToLowerInvariant() switch
        {
            "blog" => ImageSource.FromFile("book.png"),
            "video" => ImageSource.FromFile("youtube.png"),
            "sponsored" => ImageSource.FromFile("shape_plus.png"),
            // TODO same fallback color as above
            _ => ImageSource.FromFile("shape_plus.png")
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Intentionally not implemented
        throw new NotImplementedException();
    }
}
