using FreelanceRu.Models.Responses.Task;
using FreelanceRu.Pages.Popup;
using FreelanceRu.Services;
using FreelanceRu.ViewModels;
using Material.Components.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace FreelanceRu.Pages;

public partial class OrdersPage : ContentPage
{
    public OrdersPage(OrdersViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    private void NavigateInit(object sender, NavigatedToEventArgs e)
    {
        (this.BindingContext as OrdersViewModel).Initialize();
    }
}