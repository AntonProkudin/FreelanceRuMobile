using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as ProfileViewModel).Initialize();
    }
}