using FreelanceRu.Models.Responses.Task;
using FreelanceRu.Services;

namespace FreelanceRu.Pages.Popup;

public partial class ChangeOrderPagePopup : ContentPage, IQueryAttributable
{
    private int id = 0;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query == null || query.Count == 0) return;

        id = int.Parse(System.Web.HttpUtility.UrlDecode(query["id"].ToString()));
        PriceField.Text = System.Web.HttpUtility.UrlDecode(query["price"].ToString());
        DescriptionField.Text = System.Web.HttpUtility.UrlDecode(query["description"].ToString());
        TitleField.Text = System.Web.HttpUtility.UrlDecode(query["title"].ToString());

    }
    OrderServices services;
	public ChangeOrderPagePopup()
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
        await services.DeleteOrder(id);
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