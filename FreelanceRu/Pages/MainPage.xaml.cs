using FreelanceRu.Services;

namespace FreelanceRu.Pages
{
    public partial class MainPage : ContentPage
    {
        UserServices services;
        public MainPage()
        {
            services = new UserServices();
            InitializeComponent();
        }
        public MainPage(string login, string password)
        {
            services = new UserServices();
            InitializeComponent();
            LoginField.Text = login;
            PasswordField.Text = password;
        }
    }

}
