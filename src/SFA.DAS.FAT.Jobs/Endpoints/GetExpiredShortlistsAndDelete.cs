using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;

namespace SFA.DAS.FAT.Jobs.Endpoints;

public class GetExpiredShortlistsAndDelete(IShortlistService _shortlistService, ILogger<GetExpiredShortlistsAndDelete> _logger)
{
    [Function("ImpoGetExpiredShortlistsAndDeletetData")]
    public async Task RunAsync([TimerTrigger("0 0 2 * * *", RunOnStartup = true)] TimerInfo timer)
    {
        _logger.LogInformation("Get expired shortlists timer trigger function executed at: {DateTime}", DateTime.UtcNow);

        var shortListIds = (await _shortlistService.GetExpiredShortlists()).ToList();

        foreach (var shortListId in shortListIds)
        {
            await _shortlistService.DeleteShortlistForUser(shortListId);
        }

        _logger.LogInformation("Deleted {ShortListIdsCount} expired shortlists.", shortListIds.Count);
    }
}