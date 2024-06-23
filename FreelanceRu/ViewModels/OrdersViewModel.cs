using FreelanceRu.Models.Responses.Task;
using FreelanceRu.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace FreelanceRu.ViewModels;

public partial class OrdersViewModel : BaseViewModel
{
    private OrderServices services;
    public OrdersViewModel()
    {
        Orders = new ObservableCollection<TaskResponse>();
        services = new OrderServices();
        RefreshCommand = new Command(() =>
        {
            Initialize();
        });
        NewOrderCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync($"NewOrderPagePopup").ConfigureAwait(false);

        });
        DeleteOrderCommand = new Command(async (param) =>
        {
            var order = param as TaskResponse;
            await Shell.Current.GoToAsync($"ChangeOrderPagePopup?id={order.Id}&price={order.Price}&description={order.Description}&title={order.Title}");
        });
        TryDeleteOrderCommand = new Command<int>(async (param) =>
        {
            await services.DeleteOrder(param);
            Initialize();
        });
    }
    async Task GetOrders()
    {
        try
        {
            Orders = await services.GetMyOrders();
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
    public ICommand NewOrderCommand { get; set; }
    public ICommand DeleteOrderCommand { get; set; }
    public ICommand TryDeleteOrderCommand { get; set; }
}