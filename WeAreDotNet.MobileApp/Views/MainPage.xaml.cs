using WeAreDotNet.MobileApp.ViewModels;

namespace WeAreDotNet.MobileApp.Views;

public partial class MainPage
{
	private readonly MainPageViewModel mainPageViewModel;

	public MainPage(MainPageViewModel viewModel)
	{
		BindingContext = mainPageViewModel = viewModel;

		InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		await mainPageViewModel.LoadFeedItems();
    }
}


