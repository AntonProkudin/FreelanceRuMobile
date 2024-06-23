using FreelanceRu.Models.Requests.Authorization;
using FreelanceRu.Models.Responses.Authorization;
using FreelanceRu.Models.Responses.User;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;


namespace FreelanceRu.Services
{
    public class UserServices: BaseService
    {
        public async Task<TokenResponse> Login(string login, string password) 
        {
            try
            {
                var client = new RestClient(options);
                var request = new RestRequest("/api/Users/Login");
                request.AddBody(new LoginRequest() {Email = login, Password = password });
                var response = await client.PostAsync(request);
                
                return JsonConvert.DeserializeObject<TokenResponse>(response.Content);
            }
            catch
            {

                return new TokenResponse();
            }
        }
        public async Task<string> Register(SignupRequest req)
        {
            try
            {
                var client = new HttpClient(handler);
                client.BaseAddress = new Uri(Config.baseUrl);
                string json = System.Text.Json.JsonSerializer.Serialize(req, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/api/Users/Signup", content);
                string response = await result.Content.ReadAsStringAsync();

                return response;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }
        public async Task<UserInfoResponse> GetUserInfo()
        {
            try
            {
                var client = new HttpClient(handler);
                client.BaseAddress = new Uri(Config.baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
                var result = await client.GetAsync($"/api/Users/UserInfo");
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserInfoResponse>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<UserInfoResponse> GetUserInfo(int id)
        {
            try
            {
                var client = new HttpClient(handler);
                client.BaseAddress = new Uri(Config.baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.access);
                var result = await client.GetAsync($"/api/Users/UserInfo/{id}");
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserInfoResponse>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
