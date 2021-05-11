using Newtonsoft.Json;

namespace SFA.DAS.FAT.Jobs.Domain.Interfaces
{
    public interface IGetApiRequest
    {
        [JsonIgnore]
        string GetUrl { get; }
    }
}