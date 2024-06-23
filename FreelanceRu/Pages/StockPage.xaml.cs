using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages;

public partial class StockPage : ContentPage
{
	public StockPage(StockViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as StockViewModel).Initialize();
    }
}