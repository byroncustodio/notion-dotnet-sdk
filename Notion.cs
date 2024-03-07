using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models;
using NotionSDK.Models.Property;
using Database = NotionSDK.Models.Database;

namespace NotionSDK;

public class Notion
{
    private const string ApiVersion = "2022-06-28";
    private readonly HttpClient _httpClient;

    public Notion(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Configure(string baseAddress, string oAuthToken, string version = ApiVersion)
    {
        _httpClient.BaseAddress = new Uri(baseAddress);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oAuthToken);
        _httpClient.DefaultRequestHeaders.Add("Notion-Version", version);
    }

    public void Configure(Uri baseAddress, string oAuthToken, string version = ApiVersion)
    {
        _httpClient.BaseAddress = baseAddress;
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oAuthToken);
        _httpClient.DefaultRequestHeaders.Add("Notion-Version", version);
    }

    public async Task<Database> CreateDatabase(string parentId, string? title, JObject properties)
    {
        var data = new Database
        {
            Parent = new Parent
            {
                Type = "page_id",
                PageId = parentId
            },
            Properties = properties
        };

        if (!string.IsNullOrEmpty(title))
        {
            data.Title = new List<RichTextData> { new() { RichTextType = RichTextType.Text, Text = new Text { Content = title }}};
        }

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("v1/databases", UriKind.Relative),
            Content = new StringContent(
                JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}), 
                System.Text.Encoding.UTF8, 
                "application/json")
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }

        return JsonConvert.DeserializeObject<Database>(await httpResponse.Content.ReadAsStringAsync()) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }

    public async Task<Database> GetDatabaseMetadata(string id)
    {
        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"v1/databases/{id}", UriKind.Relative)
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }

        return JsonConvert.DeserializeObject<Database>(await httpResponse.Content.ReadAsStringAsync()) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }

    public async Task<QueryResponse> QueryDatabase(string id, JObject? filter = null, List<Sort>? sorts = null)
    {
        var data = new
        {
            filter,
            sorts
        };
            
        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"v1/databases/{id}/query", UriKind.Relative),
            Content = new StringContent(JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json")
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
        
        return JsonConvert.DeserializeObject<QueryResponse>(await httpResponse.Content.ReadAsStringAsync()) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
        
    public async Task<Page> AddDatabaseRow(string id, JObject properties)
    {
        var data = new Database
        {
            Parent = new Parent
            {
                Type = "database_id",
                DatabaseId = id
            },
            Properties = properties
        };

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("v1/pages", UriKind.Relative),
            Content = new StringContent(JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}), System.Text.Encoding.UTF8, "application/json")
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
        
        return JsonConvert.DeserializeObject<Page>(await httpResponse.Content.ReadAsStringAsync()) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }

    public async Task<Page> UpdateDatabaseRow(string id, JObject properties)
    {
        var data = new Database
        {
            Properties = properties
        };

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Patch,
            RequestUri = new Uri($"v1/pages/{id}", UriKind.Relative),
            Content = new StringContent(JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}), System.Text.Encoding.UTF8, "application/json")
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
        
        return JsonConvert.DeserializeObject<Page>(await httpResponse.Content.ReadAsStringAsync()) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
}