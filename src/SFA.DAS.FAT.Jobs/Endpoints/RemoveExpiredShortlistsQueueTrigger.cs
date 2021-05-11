using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;

namespace SFA.DAS.FAT.Jobs.Endpoints
{
    // public class RemoveExpiredShortlistsQueueTrigger
    // {
    //     private readonly IShortlistService _shortlistService;
    //
    //     public RemoveExpiredShortlistsQueueTrigger (IShortlistService shortlistService)
    //     {
    //         _shortlistService = shortlistService;
    //     }
    //     
    //     [FunctionName("RemoveExpiredShortlistsQueueTrigger")]
    //     public async Task QueueTrigger(
    //         [QueueTrigger("delete-shortlist")] string shortlistId, 
    //         ILogger log)
    //     {
    //         await _shortlistService.DeleteShortlistForUser(Guid.Parse(shortlistId));
    //     }
    // }
}