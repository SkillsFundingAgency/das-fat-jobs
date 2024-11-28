namespace SFA.DAS.FAT.Jobs.Domain.Interfaces;

public interface IShortlistService
{
    Task<IEnumerable<Guid>> GetExpiredShortlists();
    Task DeleteShortlistForUser(Guid userId);
}