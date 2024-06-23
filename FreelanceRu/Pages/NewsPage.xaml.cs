using FreelanceRu.Pages.Popup;
using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages;

public partial class NewsPage : ContentPage
{
	public NewsPage(NewsViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as NewsViewModel).Initialize();
    }
    private async void NotifyClicked(object sender, TouchEventArgs e)
    {
        var dlg = new NotifyPopup() { Parent = this };
        var result = await dlg.ShowAtAsync(this);
    }

    private void IconButton_Clicked(object sender, TouchEventArgs e)
    {
    }
}