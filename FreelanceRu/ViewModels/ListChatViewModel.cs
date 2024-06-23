using FreelanceRu.Models;
using FreelanceRu.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FreelanceRu.ViewModels;

public partial class ListChatViewModel : BaseViewModel
{
    private MessageService services;
    public ListChatViewModel()
    {
        MessageList = new ObservableCollection<LastMessages>();
        services = new MessageService();

        RefreshCommand = new Command(() =>
        {
            Initialize();
        });

        OpenChatPageCommand = new Command(async (param) =>
        {
            var user = param as LastMessages;
            await Shell.Current.GoToAsync($"ChatPage?id={user.UserInfo.Id}&firstName={user.UserInfo.FirstName}&lastName={user.UserInfo.LastName}&avatar={user.UserInfo.Avatar}");
        });
    }
    async System.Threading.Tasks.Task GetMessageList()
    {
        try
        {
            MessageList = await services.GetMessageList();
        }
        catch (Exception ex)
        {
            //Ignore
        }
    }
    public void Initialize()
    {
        System.Threading.Tasks.Task.Run(async () =>
        {
            IsRefreshing = true;
            await GetMessageList();
            IsRefreshing = false;
        }).ConfigureAwait(false);
    }
    private ObservableCollection<LastMessages> messageList;
    private bool isRefreshing;
    public ObservableCollection<LastMessages> MessageList
    {
        get { return messageList; }
        set { messageList = value; OnPropertyChanged("MessageList"); }
    }

    public bool IsRefreshing
    {
        get { return isRefreshing; }
        set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
    }
    public ICommand RefreshCommand { get; set; }
    public ICommand OpenChatPageCommand { get; set; }
}
