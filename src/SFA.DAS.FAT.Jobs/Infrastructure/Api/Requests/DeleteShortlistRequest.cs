using System;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;

namespace SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests
{
    public class DeleteShortlistRequest : IDeleteApiRequest
    {
        private readonly Guid _userId;

        public DeleteShortlistRequest(Guid userId)
        {
            _userId = userId;
        }

        public string DeleteUrl => $"api/shortlist/users/{_userId}";
    }
}