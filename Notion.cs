using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models;
using NotionSDK.Models.Block;

namespace NotionSDK
{
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

        public async Task<Database> CreateDatabase(string parentId, string? title, object properties)
        {
            var data = new
            {
                parent = new Models.Parent.Page
                {
                    Type = "page_id",
                    PageId = parentId
                },
                title = title == null ? null : new List<RichText>
                {
                    new()
                    {
                        Type = RichTextType.Text,
                        Text = new Text()
                        {
                            Content = title
                        }
                    }
                },
                properties
            };

            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("v1/databases", UriKind.Relative),
                Content = new StringContent(
                    JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}), 
                    System.Text.Encoding.UTF8, 
                    "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Database>(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
        }

        public async Task<Database> GetDatabaseMetadata(string id)
        {
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"v1/databases/{id}", UriKind.Relative),
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Database>(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
        }

        public async Task<QueryResponse> QueryDatabase(string id, string filter)
        {
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"v1/databases/{id}/query", UriKind.Relative),
                Content = new StringContent(filter, System.Text.Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QueryResponse>(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
        }
        
        public async Task AddDatabaseRow(string id, JObject properties)
        {
            var data = new
            {
                parent = new Models.Parent.Database()
                {
                    Type = "database_id",
                    DatabaseId = id
                },
                properties
            };

            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("v1/pages", UriKind.Relative),
                Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        public async Task UpdateDatabaseRow(string id, JObject properties)
        {
            var data = new
            {
                properties
            };

            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"v1/pages/{id}", UriKind.Relative),
                Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
    }
}
