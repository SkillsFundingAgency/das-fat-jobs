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