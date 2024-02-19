using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models;
using NotionSDK.Models.Block;

namespace NotionSDK
{
    public class Notion
    {
        private const string API_VERSION = "2022-06-28";

        private readonly HttpClient _httpClient;

        public Notion(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Init(string baseAddress, string oAuthToken, string version = API_VERSION)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oAuthToken);
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", version);
        }

        public void Init(Uri baseAddress, string oAuthToken, string version = API_VERSION)
        {
            _httpClient.BaseAddress = baseAddress;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oAuthToken);
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", version);
        }

        public async Task<JArray> QueryDatabase(string databaseId, string filter)
        {
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(string.Format("v1/databases/{0}/query", databaseId), UriKind.Relative),
                Content = new StringContent(filter, System.Text.Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            string content = await httpResponse.Content.ReadAsStringAsync();
            dynamic deserializedContent = JsonConvert.DeserializeObject(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
            return deserializedContent["results"];
        }

        public async Task<List<T>?> QueryDatabase<T>(string databaseId, string filter)
        {
            return (await QueryDatabase(databaseId, filter)).ToObject<List<T>>();
        }

        public async Task<Database> CreateDatabase(string parentId, string dbTitle, object properties)
        {
            var data = new
            {
                parent = new Models.Parent.Page()
                {
                    Type = "page_id",
                    PageId = parentId
                },
                title = new List<RichText>
                {
                    new()
                    {
                        Type = RichTextType.Text,
                        Text = new Text()
                        {
                            Content = dbTitle
                        }
                    }
                },
                properties
            };

            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("v1/databases", UriKind.Relative),
                Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Database>(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
        }

        public async Task<Database> GetDatabase(string databaseId)
        {
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(string.Format("v1/databases/{0}", databaseId), UriKind.Relative)
            };

            using HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var message = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Database>(content) ?? throw new Exception("Deserialized JSON resulted in null value.");
        }

        public async Task AddDatabaseRow(string databaseId, object properties)
        {
            var data = new
            {
                parent = new Models.Parent.Database()
                {
                    Type = "database_id",
                    DatabaseId = databaseId
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

        public async Task UpdateDatabaseRow(string databaseId, object properties)
        {
            var data = new
            {
                properties
            };

            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri(string.Format("v1/pages/{0}", databaseId), UriKind.Relative),
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
