using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Responses;

namespace SFA.DAS.FAT.Jobs.Application.Services
{
    public class ShortlistService
    {
        private readonly IApiClient _apiClient;

        public ShortlistService (IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IEnumerable<Guid>> GetExpiredShortlists()
        {
            var shortlistUserIds =
                await _apiClient.Get<GetExpiredShortlistResponse>(
                    new GetExpiredShortlistsRequest(ConfigurationConstants.ExpiryPeriodInDays));

            return shortlistUserIds.UserIds;
        }

        public async Task DeleteShortlistForUser(Guid userId)
        {
            await _apiClient.Delete(new DeleteShortlistRequest(userId));
        }
    }
}