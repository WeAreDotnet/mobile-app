using WeAreDotNet.MobileApp.ViewModels;

namespace WeAreDotNet.MobileApp.Views;

[QueryProperty(nameof(Nickname), "nickname")]
public partial class ProfilePage : ContentPage
{
	private readonly ProfilePageViewModel profilePageViewModel;

	public string Nickname { get; set; }

	public ProfilePage(ProfilePageViewModel viewModel)
	{
		BindingContext = profilePageViewModel = viewModel;

		InitializeComponent();
	}
}
