using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages.Popup;

public partial class UserInfoPagePopup : ContentPage
{
	public UserInfoPagePopup(UserInfoCheckPopupViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as UserInfoCheckPopupViewModel).Initialize();
    }
}