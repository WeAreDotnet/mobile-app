using WeAreDotNet.MobileApp.ViewModels;

namespace WeAreDotNet.MobileApp.Views;

public partial class MembersOverviewPage : ContentPage
{
    private readonly MembersOverviewPageViewModel membersOverviewPageViewModel;

    public MembersOverviewPage(MembersOverviewPageViewModel viewModel)
	{
        BindingContext = membersOverviewPageViewModel = viewModel;

        InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await membersOverviewPageViewModel.LoadMembers();
    }
}
