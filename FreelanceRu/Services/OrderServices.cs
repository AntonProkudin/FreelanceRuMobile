using FreelanceRu.Models.Requests.Task;
using FreelanceRu.Models.Responses.Task;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace FreelanceRu.Services;

public class OrderServices: BaseService
{
    public async Task<ObservableCollection<TaskResponse>> GetMyOrders()
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.GetAsync($"/api/Tasks/ThisUser");
            string response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<TaskResponse>>(response);
        }
        catch (Exception ex)
        {
            return null;
        }

    }
    public async Task DeleteOrder(int id)
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.DeleteAsync($"/api/Tasks/{id}");
            result.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
        }
    }
    public async Task<ObservableCollection<TaskResponse>> GetOrdersByTS()
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", App.access);
            var result = await client.GetAsync($"/api/Tasks?ts={WebUtility.UrlEncode($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}")}");
            string response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<TaskResponse>>(response);

        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<TaskResponse> PostOrder(TaskRequest req)
    {
        try
        {
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(Config.baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
            string json = System.Text.Json.JsonSerializer.Serialize(req, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/api/Tasks", content);
            result.EnsureSuccessStatusCode();
            string response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TaskResponse>(response);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
