using WeAreDotNet.MobileApp.Views;

namespace WeAreDotNet.MobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("profile", typeof(ProfilePage));
    }
}

