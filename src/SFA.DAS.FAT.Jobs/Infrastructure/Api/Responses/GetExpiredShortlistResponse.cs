using Newtonsoft.Json;

namespace SFA.DAS.FAT.Jobs.Infrastructure.Api.Responses;

public class GetExpiredShortlistResponse
{
    [JsonProperty("userIds")]
    public required List<Guid> UserIds { get; set; }
}