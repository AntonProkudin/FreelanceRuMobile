using FreelanceRu.Models.Requests.Authorization;
using FreelanceRu.Models.Responses.Authorization;
using FreelanceRu.Services;

namespace FreelanceRu.Pages
{
    public partial class MainPage : ContentPage
    {
        private void OnButtonNavigateClicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new RegistrationPage();
        }
        private async void LoginClicked(object sender, System.EventArgs e)
        {
            activityIndicator.IsVisible = true;
            if (PasswordField.Text == String.Empty || LoginField.Text == String.Empty)
            {
                await this.DisplayAlert("Ошибка!", "Поля пустые", "OK");
                activityIndicator.IsVisible = false;
                return;
            }

            try
            {
                var request = new LoginRequest() { Email = LoginField.Text, Password = PasswordField.Text };
                //var response = await services.CallWebApi<LoginRequest, TokenResponse>("/api/Users/Login", HttpMethod.Post, request);
                var response = await services.Login(LoginField.Text, PasswordField.Text);
                if (response.AccessToken == null || response.AccessToken == String.Empty)
                {
                    await this.DisplayAlert("Ошибка!", "Токен не получен", "OK");
                    activityIndicator.IsVisible = false;
                    return;
                }
                App.access = response.AccessToken;
                App.refresh = response.RefreshToken;

                await SecureStorage.Default.SetAsync("access", App.access);
                await SecureStorage.Default.SetAsync("refresh", App.refresh);

                Application.Current.MainPage = new AppShell();

            }
            catch (Exception ex)
            {
                activityIndicator.IsVisible = false;
                await this.DisplayAlert("Ошибка!", ex.Message, "OK");
            }
            activityIndicator.IsVisible = false;
        }
    }

}
