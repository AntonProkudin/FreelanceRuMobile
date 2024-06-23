using FreelanceRu.Models.Requests.Authorization;
using FreelanceRu.Models.Responses.Authorization;

namespace FreelanceRu.Pages;

public partial class RegistrationPage : ContentPage
{
    private void OnButtonNavigateClicked(object sender, System.EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }
    private async void RegisterClicked(object sender, System.EventArgs e)
    {
        activityIndicator.IsVisible = true;
        if (PasswordField.Text == String.Empty || RepeatPasswordField.Text == String.Empty || LoginField.Text == String.Empty || FirstNameField.Text == String.Empty || SecondNameField.Text == String.Empty)
        {
            await this.DisplayAlert("Ошибка!", "Поля пустые", "OK");
            activityIndicator.IsVisible = false;
            return;
        }

        try
        {
            var response = await services.Register(new SignupRequest()
            {
                Email = LoginField.Text,
                Password = PasswordField.Text,
                ConfirmPassword = RepeatPasswordField.Text,
                FirstName = FirstNameField.Text,
                LastName = SecondNameField.Text,
                Ts = DateTime.Now
            });
            if (!response.Contains("@"))
            {
                await this.DisplayAlert("Ошибка!", $"Что-то пошло не так!", "OK");
                activityIndicator.IsVisible = false;
                return;
            }
            await this.DisplayAlert("Уведомление!", "Регистрация успешна!", "OK");
            Application.Current.MainPage = new MainPage(LoginField.Text, PasswordField.Text);

        }
        catch (Exception ex)
        {
            activityIndicator.IsVisible = false;
            await this.DisplayAlert("Ошибка!", ex.Message, "OK");
        }
        activityIndicator.IsVisible = false;
    }
}