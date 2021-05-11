using System;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.FAT.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.FAT.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingDeleteShortlistRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Built(Guid userId)
        {
            //Act
            var actual = new DeleteShortlistRequest(userId);
            
            //Assert
            actual.DeleteUrl.Should().Be($"shortlist/users/{userId}");
        }
    }
}