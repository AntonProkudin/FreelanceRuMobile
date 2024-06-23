using FreelanceRu.Services;

namespace FreelanceRu.Pages.Popup;

public partial class NewOrderPagePopup : ContentPage
{
    OrderServices services;
	public NewOrderPagePopup()
	{
		InitializeComponent();
        services = new OrderServices();
	}

    private void Button_Clicked(object sender, TouchEventArgs e)
    {
        Shell.Current.SendBackButtonPressed();
    }
    private async void Button_Clicked_1(object sender, TouchEventArgs e)
    {
        await services.PostOrder(
            new Models.Requests.Task.TaskRequest() 
            {
                 CategoryId = 1,
                 Price = decimal.Parse(PriceField.Text),
                 Description = DescriptionField.Text,
                 Title = TitleField.Text,
                 IsCompleted = false,
                 Ts = DateTime.Now,
}
            );
        Shell.Current.SendBackButtonPressed();
    }
}