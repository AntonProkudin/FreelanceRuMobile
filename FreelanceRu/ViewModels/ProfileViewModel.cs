using FreelanceRu.Models.Responses.User;
using FreelanceRu.Services;
using System.Windows.Input;

namespace FreelanceRu.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    private UserServices services;
    public ProfileViewModel()
    {
        UserInfo = new UserInfoResponse();
        services = new UserServices();
        RefreshCommand = new Command(() =>
        {
            Initialize();
        });
    }
    async Task GetUserInfo()
    {
        try
        {
            UserInfo = await services.GetUserInfo();
           // url = UserInfo.Avatar.Replace("https://192.168.1.104:7124", "http://192.168.1.104:5156");
            Url = UserInfo.Avatar.Replace("https://192.168.1.104:7124", "http://192.168.1.104:5156"); 
        }
        catch (Exception ex)
        {
            //Ignore
        }
    }
    async Task DeleteSkill(int param)
    {
        int Id = param;
        await AppShell.Current.DisplayAlert("Kworking", "Нажато", "OK");
    }
    public void Initialize()
    {
        Task.Run(async () =>
        {
            IsRefreshing = true;
            await GetUserInfo();
            IsRefreshing = false;
        }).ConfigureAwait(false);
    }
    private UserInfoResponse userInfo;
    private bool isRefreshing;
    private string url;
    public UserInfoResponse UserInfo
    {
        get { return userInfo; }
        set { userInfo = value; OnPropertyChanged("UserInfo"); }
    }
    public string Url
    {
        get { return url; }
        set { url = value; OnPropertyChanged("Url"); }
    }

    public bool IsRefreshing
    {
        get { return isRefreshing; }
        set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
    }
    public ICommand RefreshCommand { get; set; }
}
