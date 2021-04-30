using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SFA.DAS.FAT.Jobs.Domain.Configuration;

namespace SFA.DAS.FAT.Jobs.Endpoints
{
    public class RemoveExpiredShortlistsHttp
    {
        private FatJobsApiConfiguration _config;
        public RemoveExpiredShortlistsHttp (IOptions<FatJobsApiConfiguration> config)
        {
            _config = config.Value;
        }
        [FunctionName("RemoveExpiredShortlistsHttp")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post")]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            log.LogInformation($"{_config.BaseUrl}");
            log.LogInformation(_config.Key);

            await Task.FromResult("Done");

            return new NoContentResult();
            
        }
    }
}