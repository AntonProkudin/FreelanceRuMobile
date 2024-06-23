using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FreelanceRu.Services;

public class BaseService
{
    public JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public HttpClientHandler handler = new HttpClientHandler() 
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
        {
            return true;
        }
    };
    public RestClientOptions options = new RestClientOptions(Config.baseUrl)
    {
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
    };
}
