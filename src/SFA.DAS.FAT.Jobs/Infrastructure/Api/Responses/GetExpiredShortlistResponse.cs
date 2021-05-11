using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SFA.DAS.FAT.Jobs.Infrastructure.Api.Responses
{
    public class GetExpiredShortlistResponse
    {
        [JsonProperty("userIds")]
        public List<Guid> UserIds { get; set; }
    }
}