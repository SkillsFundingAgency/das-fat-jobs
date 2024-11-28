using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.FAT.Jobs.Application.Services;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Responses;
using SFA.DAS.Testing.AutoFixture;
using System.Threading.Tasks;

namespace SFA.DAS.FAT.Jobs.UnitTests.Application.Services;

public class WhenGettingExpiredShortlists
{
    [Test, MoqAutoData]
    public async Task Then_The_Api_Is_Called_And_Result_Returned(
        GetExpiredShortlistResponse response,
        [Frozen]Mock<IApiClient> apiClient,
        ShortlistService service)
    {
        apiClient.Setup(x =>
            x.Get<GetExpiredShortlistResponse>( 
                It.Is<GetExpiredShortlistsRequest>(c=>c.GetUrl.Contains($"expired?expiryInDays={ConfigurationConstants.ExpiryPeriodInDays}"))))
                .ReturnsAsync(response);

        var actual = await service.GetExpiredShortlists();

        actual.Should().BeEquivalentTo(response.UserIds);
    }
}