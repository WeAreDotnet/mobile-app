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

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await profilePageViewModel.LoadProfile(Nickname);
    }
}
