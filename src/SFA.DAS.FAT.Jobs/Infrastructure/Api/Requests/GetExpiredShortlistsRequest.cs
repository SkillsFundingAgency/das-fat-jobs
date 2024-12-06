using SFA.DAS.FAT.Jobs.Domain.Interfaces;

namespace SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;

public class GetExpiredShortlistsRequest : IGetApiRequest
{
    private readonly uint _expiryInDays;

    public GetExpiredShortlistsRequest(uint expiryInDays)
    {
        _expiryInDays = expiryInDays;
    }

    public string GetUrl => $"shortlist/expired?expiryInDays={_expiryInDays}";
}