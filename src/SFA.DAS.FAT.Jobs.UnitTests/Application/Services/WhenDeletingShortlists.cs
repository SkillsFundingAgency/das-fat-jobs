using System;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using SFA.DAS.FAT.Jobs.Application.Services;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAT.Jobs.UnitTests.Application.Services
{
    public class WhenDeletingShortlists
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_With_The_Shortlist_UserId(
            Guid userId,
            [Frozen]Mock<IApiClient> apiClient,
            ShortlistService service)
        {
            await service.DeleteShortlistForUser(userId);
            
            apiClient.Verify(x=>x.Delete(It.Is<DeleteShortlistRequest>(c=>c.DeleteUrl.Contains(userId.ToString()))));
        }
    }
}