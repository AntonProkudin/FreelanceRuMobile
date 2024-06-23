using FreelanceRu.Services;

namespace FreelanceRu.Pages;

public partial class RegistrationPage : ContentPage
{
    UserServices services;
    public RegistrationPage()
	{
		InitializeComponent();
        services = new UserServices();
    }
}