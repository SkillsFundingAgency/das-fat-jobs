using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FATJobs.Domain.Configuration;

namespace SFA.DAS.FAT.Jobs.Infrastructure.Api
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private readonly FatJobsApiConfiguration _config;

        public ApiClient(HttpClient client, IOptions<FatJobsApiConfiguration> config)
        {
            _client = client;
            _config = config.Value;
            _client.BaseAddress = new Uri(_config.BaseUrl);
        }

        public async Task<TResponse> Get<TResponse>(IGetApiRequest request)
        {
            AddHeaders();

            var response = await _client.GetAsync(request.GetUrl).ConfigureAwait(false);

            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(json);    
            }
            
            response.EnsureSuccessStatusCode();
            
            return default;
        }
        public async Task Delete(IDeleteApiRequest request)
        {
            AddHeaders();
            var response = await _client.DeleteAsync(request.DeleteUrl)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
        
        private void AddHeaders()
        {
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Key);
            _client.DefaultRequestHeaders.Add("X-Version", "1");
        }
    }
}