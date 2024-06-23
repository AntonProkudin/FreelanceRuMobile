using FreelanceRu.Models.Responses.Task;
using FreelanceRu.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace FreelanceRu.ViewModels;

public partial class StockViewModel : BaseViewModel
{
    private OrderServices services;
    private UserServices userService;
    public StockViewModel()
    {
        Orders = new ObservableCollection<TaskResponse>();
        services = new OrderServices();
        userService = new UserServices();
        RefreshCommand = new Command(() =>
        {
            Initialize();
        });
        CheckProfileCommand = new Command<int>(async (param) =>
        {

            await Shell.Current.GoToAsync($"UserInfoPagePopup?id={param}");
        });
        NavigateChatCommand = new Command<int>(async (param) =>
        {
            var user = await userService.GetUserInfo(param);
            await Shell.Current.GoToAsync($"ChatPage?id={param}&firstName={user.FirstName}&lastName={user.LastName}&avatar={user.Avatar}");
        });
    }
    async Task GetOrders()
    {
        try
        {
            Orders = await services.GetOrdersByTS();
        }
        catch (Exception ex) 
        {
            //Ignore
        }
    }
    public void Initialize()
    {
        Task.Run(async () =>
        {
            IsRefreshing = true;
            await GetOrders();
            IsRefreshing = false;
        }).ConfigureAwait(false);
    }
    private ObservableCollection<TaskResponse> orders;
    private bool isRefreshing;
    public ObservableCollection<TaskResponse> Orders
    {
        get { return orders; }
        set { orders = value; OnPropertyChanged("Orders"); }
    }

    public bool IsRefreshing
    {
        get { return isRefreshing; }
        set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
    }
    public ICommand RefreshCommand { get; set; }
    public ICommand CheckProfileCommand { get; set; }
    public ICommand NavigateChatCommand { get; set; }
}