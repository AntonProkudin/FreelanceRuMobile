using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages;

public partial class ListChatPage : ContentPage
{
    public ListChatPage(ListChatViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as ListChatViewModel).Initialize();
    }
}