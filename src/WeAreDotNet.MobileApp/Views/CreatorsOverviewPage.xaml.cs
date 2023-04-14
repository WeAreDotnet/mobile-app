using WeAreDotNet.MobileApp.ViewModels;

namespace WeAreDotNet.MobileApp.Views;

public partial class CreatorsOverviewPage : ContentPage
{
    private readonly CreatorsOverviewPageViewModel creatorsOverviewPageViewModel;

    public CreatorsOverviewPage(CreatorsOverviewPageViewModel viewModel)
    {
        BindingContext = creatorsOverviewPageViewModel = viewModel;

        InitializeComponent();
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await creatorsOverviewPageViewModel.LoadCreators();
    }
}
