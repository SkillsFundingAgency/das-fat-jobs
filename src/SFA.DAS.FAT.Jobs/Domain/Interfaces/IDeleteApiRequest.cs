using Newtonsoft.Json;

namespace SFA.DAS.FAT.Jobs.Domain.Interfaces
{
    public interface IDeleteApiRequest
    {
        [JsonIgnore]
        string DeleteUrl { get;}
    }
}