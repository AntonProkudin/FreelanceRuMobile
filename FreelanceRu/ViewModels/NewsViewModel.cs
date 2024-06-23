using FreelanceRu.Models.Responses.News;
using FreelanceRu.Models.Responses.Task;
using FreelanceRu.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace FreelanceRu.ViewModels;

public partial class NewsViewModel : BaseViewModel
{
    private NewsServices services;
    public NewsViewModel()
    {
        News = new ObservableCollection<NewsResponseFormated>();
        services = new NewsServices();
        RefreshCommand = new Command(() =>
        {
            Initialize();
        });
        ChangeVisibilityCommand = new Command(async (param) => 
        {
            await ChangeVisibility((int)param);
        });
    }
    async Task GetNews()
    {
        try
        {
            var newsResponse = await services.GetNewsByTS();
            foreach (var item in newsResponse)
            {
                News.Add(new() { Id = item.Id, Description = item.Description, Title = item.Title, Ts = item.Ts, Url = item.Url});
            }
        }
        catch (Exception ex) 
        {
            //Ignore
        }
    }
    async Task ChangeVisibility(int param)
    {
        var item = News.Where(x => x.Id == param).First();
        if (item.Visible)
            item.Visible = false;
        else
            item.Visible = true;
    }
    public void Initialize()
    {
        Task.Run(async () =>
        {
            IsRefreshing = true;
            await GetNews();
            IsRefreshing = false;
        }).ConfigureAwait(false);
    }
    private ObservableCollection<NewsResponseFormated> news;
    private bool isRefreshing;
    public ObservableCollection<NewsResponseFormated> News
    {
        get { return news; }
        set { news = value; OnPropertyChanged("News"); }
    }

    public bool IsRefreshing
    {
        get { return isRefreshing; }
        set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
    }
    public ICommand RefreshCommand { get; set; }
    public ICommand ChangeVisibilityCommand { get; set; }
}