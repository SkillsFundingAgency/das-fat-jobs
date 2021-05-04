using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;

namespace SFA.DAS.FAT.Jobs.Endpoints
{
    public class GetExpiredShortlists
    {
        private readonly IShortlistService _shortlistService;

        public GetExpiredShortlists (IShortlistService shortlistService)
        {
            _shortlistService = shortlistService;
        }
        [FunctionName("GetExpiredShortlists")]
        public async Task RunAsync(
            [TimerTrigger("0 0 3 * * *")] TimerInfo myTimer, 
            ILogger log,
            [Queue("delete-shortlist")] ICollector<string> deleteShortlistQueue)
        {
            log.LogInformation($"Get expired shortlists timer trigger function executed at: {DateTime.UtcNow}");

            var shortListIds = (await _shortlistService.GetExpiredShortlists()).ToList();

            foreach (var shortListId in shortListIds)
            {
                deleteShortlistQueue.Add(shortListId.ToString());
            }
            
            log.LogInformation($"Added {shortListIds.Count} shortlists to be deleted.");
        }
    }
}