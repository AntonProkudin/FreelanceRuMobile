using FreelanceRu.Models;
using FreelanceRu.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task = System.Threading.Tasks.Task;

namespace FreelanceRu.ViewModels;

public class ChatViewModel : BaseViewModel, IQueryAttributable
{
    private MessageService services;
    HubConnection hubConnection;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query == null || query.Count == 0) return;

        UserId = int.Parse(System.Web.HttpUtility.UrlDecode(query["id"].ToString()));
        FirstName = System.Web.HttpUtility.UrlDecode(query["firstName"].ToString());
        LastName = System.Web.HttpUtility.UrlDecode(query["lastName"].ToString());
        Avatar = System.Web.HttpUtility.UrlDecode(query["avatar"].ToString());
    }

    public ChatViewModel()
    {
        
        MessageList = new ObservableCollection<MessageFormat>();
        services = new MessageService();

        hubConnection = new HubConnectionBuilder()
            .WithUrl("http://192.168.1.104:5296/chat", options =>
            {
                options.Headers.Add("Authorization", "Bearer " + App.access);
                options.HttpMessageHandlerFactory = m => services.handler;
            }).Build();
        
        
        SendMessageCommand = new Command(async () => await SendMessage());
        RefreshCommand = new Command(() =>
        {
            Initialize();
        });

        hubConnection.On<Message>("ReceiveMessage", SendLocalMessage);

        Task.Run(async() =>
        {
            await hubConnection.StartAsync();
        }).ConfigureAwait(false);
    }
    async Task GetMessageList()
    {
        try
        {
            var response =  await services.GetMessageListUser(userId);
            foreach (var item in response)
            {
                if (item.FromUserId == UserId)
                { 
                    MessageList.Add(new MessageFormat() { FromUserId = item.FromUserId, Text = item.Text, Id = item.Id, SendTime = item.SendTime, ToUserId = item.ToUserId, IsRead = item.IsRead});
                }
                else
                {
                    MessageList.Add(new MessageFormat() { FromUserId = item.FromUserId, Text = item.Text, Id = item.Id, SendTime = item.SendTime, ToUserId = item.ToUserId, IsRead = item.IsRead, Color = Color.FromArgb("#303030"), layoutOptions = LayoutOptions.End });
                }
            }
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
    async Task SendMessage()
    {
        try
        {
            var m = new Message() { FromUserId = UserId, Text = Field, SendTime = DateTime.Now, ToUserId = UserId, IsRead = false };
            await hubConnection.InvokeAsync("SendMessage", m);
            SendLocalMessage(m);
            Field = "";
        }
        catch (Exception ex)
        {

        }
    }
    private void SendLocalMessage(Message message)
    {
        if (message.Id == UserId)
        {
            MessageList.Add(new MessageFormat() { FromUserId = message.FromUserId, Text = message.Text, Id = message.Id, SendTime = message.SendTime, ToUserId = message.ToUserId, IsRead = message.IsRead });
        }
        else
        {
            MessageList.Add(new MessageFormat() { FromUserId = message.FromUserId, Text = message.Text, Id = message.Id, SendTime = message.SendTime, ToUserId = message.ToUserId, IsRead = message.IsRead, Color = Color.FromArgb("#303030"), layoutOptions = LayoutOptions.End });
        }
    }
    private ObservableCollection<MessageFormat> messageList;
    private bool isRefreshing;
    public int userId;
    private string field;
    private string firstName;
    private string lastName;
    private string avatar;
    public int UserId
    {
        get { return userId; }
        set { userId = value; OnPropertyChanged("UserId"); }
    }
    public ObservableCollection<MessageFormat> MessageList
    {
        get { return messageList; }
        set { messageList = value; OnPropertyChanged("MessageList"); }
    }
    public string Field
    {
        get { return field; }
        set { field = value; OnPropertyChanged("Field"); }
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; OnPropertyChanged("FirstName"); }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; OnPropertyChanged("LastName"); }
    }
    public string Avatar
    {
        get { return avatar; }
        set { avatar = value; OnPropertyChanged("Avatar"); }
    }
    public bool IsRefreshing
    {
        get { return isRefreshing; }
        set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
    }
    public ICommand RefreshCommand { get; set; }
    public ICommand SendMessageCommand { get; }
}