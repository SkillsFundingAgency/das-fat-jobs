using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.FAT.Jobs.Domain.Interfaces
{
    public interface IShortlistService
    {
        Task<IEnumerable<Guid>> GetExpiredShortlists();
        Task DeleteShortlistForUser(Guid userId);
    }
}