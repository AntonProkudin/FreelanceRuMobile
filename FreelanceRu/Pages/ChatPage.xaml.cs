using FreelanceRu.ViewModels;

namespace FreelanceRu.Pages;

public partial class ChatPage : ContentPage
{
    public ChatPage(ChatViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as ChatViewModel).Initialize();
    }
}