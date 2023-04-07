using System;
using System.Globalization;
using WeAreDotNet.MobileApp.Models;

namespace WeAreDotNet.MobileApp.Converters;

public class FeedEntryToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var feedEntryType = value as string;

        if (string.IsNullOrWhiteSpace(feedEntryType))
        {
            // TODO What is the gracefall fallback color?
            return Colors.White;
        }

        return feedEntryType.ToLowerInvariant() switch
        {
            "blog" => Colors.Blue,
            "video" => Colors.Red,
            "sponsored" => Colors.Gray,
            // TODO same fallback color as above
            _ => Colors.White
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Intentionally not implemented
        throw new NotImplementedException();
    }
}
