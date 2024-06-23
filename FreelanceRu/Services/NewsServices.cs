using FreelanceRu.Models.Responses.News;
using FreelanceRu.Models.Responses.Task;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;

namespace FreelanceRu.Services;

public class NewsServices: BaseService
{
    public async Task<ObservableCollection<NewsResponse>> GetNewsByTS()
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.GetAsync($"/api/News?ts={WebUtility.UrlEncode($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}")}");
            string response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<NewsResponse>>(response);

        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
