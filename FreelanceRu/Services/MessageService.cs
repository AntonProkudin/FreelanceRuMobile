using FreelanceRu.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace FreelanceRu.Services;

public class MessageService: BaseService
{
    public async Task<ObservableCollection<LastMessages>> GetMessageList()
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.GetAsync($"/api/Message/Lastest?ts={WebUtility.UrlEncode($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}")}");
            string response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<LastMessages>>(response);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<ObservableCollection<Message>> GetMessageListUser(int id)
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.GetAsync($"/api/Message?ts={WebUtility.UrlEncode($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}")}&toUserId={id}");
            string response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<Message>>(response);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async System.Threading.Tasks.Task SendMessage(Message req)
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
            string json = System.Text.Json.JsonSerializer.Serialize(req, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/api/Message", content);
            result.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {

        }
    }
}
