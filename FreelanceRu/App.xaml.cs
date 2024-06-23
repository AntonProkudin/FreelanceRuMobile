using FreelanceRu.Pages;

namespace FreelanceRu
{
    public partial class App : Application
    {
        public static string access = String.Empty;
        public static string refresh = String.Empty;
        public App()
        {
            InitializeComponent();
            try
            {
                Task.Run(async () =>
                {
                    access = await SecureStorage.Default.GetAsync("access");
                    refresh = await SecureStorage.Default.GetAsync("refresh");
                }).Wait();
                if (access == String.Empty || access ==  null)
                    MainPage = new MainPage();
                else
                    MainPage = new AppShell();

            }
            catch (Exception)
            {
                MainPage = new MainPage();
            }
        }
    }
}
