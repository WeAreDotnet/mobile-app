using Microsoft.Extensions.Logging;
using WeAreDotNet.MobileApp.Services;
using WeAreDotNet.MobileApp.ViewModels;
using WeAreDotNet.MobileApp.Views;

namespace WeAreDotNet.MobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Pages
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<CreatorsPage>();

		// ViewModels
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<CreatorsPageViewModel>();

        // Services
        builder.Services.AddSingleton<WeAreDotNetService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

