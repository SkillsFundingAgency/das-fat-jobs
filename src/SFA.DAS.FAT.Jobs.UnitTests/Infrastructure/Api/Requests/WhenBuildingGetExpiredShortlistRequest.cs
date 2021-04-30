using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.FAT.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingGetExpiredShortlistRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Build(uint expiryInDays)
        {
            //Act
            var actual = new GetExpiredShortlistsRequest(expiryInDays);
            
            //Assert
            actual.GetUrl.Should().Be($"shortlist/expired?expiryInDays={expiryInDays}");
        }
    }
}