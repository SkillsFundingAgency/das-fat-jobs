using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace SFA.DAS.FAT.Jobs.Endpoints
{
    public class RemoveExpiredShortlists
    {
        [FunctionName("RemoveExpiredShortlists")]
        public async Task RunAsync([TimerTrigger("0 0 3 * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"RemoveExpiredShortlists Timer trigger function executed at: {DateTime.UtcNow}");
            await Task.FromResult("Done");
        }
    }
}