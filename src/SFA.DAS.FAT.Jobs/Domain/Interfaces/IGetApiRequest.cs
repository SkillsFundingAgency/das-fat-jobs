using Newtonsoft.Json;

namespace SFA.DAS.FATJobs.Domain.Interfaces
{
    public interface IGetApiRequest
    {
        [JsonIgnore]
        string GetUrl { get; }
    }
}