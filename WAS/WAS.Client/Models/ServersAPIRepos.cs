using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace WAS.Client.Models
{
    public class ServersAPIRepos : IServersRepos
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiName = "ServersAPI";

        public ServersAPIRepos(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Server>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);
            httpClient.GetAsync("servers.josn");

            var response = await httpClient.GetAsync("servers.json");

            response.EnsureSuccessStatusCode(); //200 code

            var content = await response.Content.ReadAsStringAsync();

            // Firebase creates a null object when there is no data
            if (!string.IsNullOrEmpty(content) && content != "null")
            {
                return JsonConvert.DeserializeObject<List<Server>>(content) ?? new List<Server>();
            }
            else
            {
                return new List<Server>();
            }
        }

        // Firebase does not accept the POST method, so we use PUT instead 
        public async Task AddAsync(Server server)
        {
            server.Id = await GetNextIdAsync();
            var httpClient = _httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"servers/{server.Id}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Server?> GetByIdAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);

            var response = await httpClient.GetAsync($"servers/{id}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Server>(content);
        }

        public async Task UpdateAsync(Server server)
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"servers/{server.Id}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);
            var response = await httpClient.DeleteAsync($"servers/{id}.json");
            //response.EnsureSuccessStatusCode();
        }

        public async Task<int> GetNextIdAsync()
        {
            var servers = await GetAllAsync();
            if (servers is not null && servers.Any())
                return servers.Where(x => x is not null).Max(x => x.Id) + 1;

            return 1;
        }
    }
}
