using System.Threading.Tasks;

namespace SFA.DAS.FAT.Jobs.Domain.Interfaces
{
    public interface IApiClient
    {
        Task<TResponse> Get<TResponse>(IGetApiRequest request);
        Task Delete(IDeleteApiRequest request);
    }
}