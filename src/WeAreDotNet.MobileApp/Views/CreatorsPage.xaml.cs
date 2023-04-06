using WeAreDotNet.MobileApp.ViewModels;

namespace WeAreDotNet.MobileApp.Views;

public partial class CreatorsPage : ContentPage
{
    private readonly CreatorsPageViewModel creatorsPageViewModel;

    public CreatorsPage(CreatorsPageViewModel viewModel)
	{
        BindingContext = creatorsPageViewModel = viewModel;

        InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await creatorsPageViewModel.LoadRecentJoins();
    }
}
