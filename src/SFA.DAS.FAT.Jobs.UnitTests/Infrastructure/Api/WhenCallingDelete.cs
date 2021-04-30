using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api;
using SFA.DAS.FATJobs.Domain.Configuration;

namespace SFA.DAS.FAT.Jobs.UnitTests.Infrastructure.Api
{
    public class WhenCallingDelete
    {
        [Test, AutoData]
        public async Task Then_The_Endpoint_Is_Called(
            int id,
            FatJobsApiConfiguration config)
        {
            //Arrange
            config.BaseUrl = $"https://test.local/{config.BaseUrl}/";
            var configMock = new Mock<IOptions<FatJobsApiConfiguration>>();
            configMock.Setup(x => x.Value).Returns(config);
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Accepted
            };
            var deleteTestRequest = new DeleteTestRequest(id);
            var expectedUrl = deleteTestRequest.DeleteUrl;
            var httpMessageHandler = MessageHandler.SetupMessageHandlerMock(response, config.BaseUrl + expectedUrl, config.Key, HttpMethod.Delete);
            var client = new HttpClient(httpMessageHandler.Object);
            var apiClient = new ApiClient(client, configMock.Object);
            
            
            //Act
            await apiClient.Delete(deleteTestRequest);

            //Assert
            httpMessageHandler.Protected()
                .Verify<Task<HttpResponseMessage>>(
                    "SendAsync", Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(c =>
                        c.Method.Equals(HttpMethod.Delete)
                        && c.RequestUri.AbsoluteUri.Equals(config.BaseUrl + expectedUrl)),
                    ItExpr.IsAny<CancellationToken>()
                );
        }
        
        [Test, AutoData]
        public void Then_If_It_Is_Not_Successful_An_Exception_Is_Thrown(
            int id,
            FatJobsApiConfiguration config)
        {
            //Arrange
            config.BaseUrl = $"https://test.local/{config.BaseUrl}/";
            var configMock = new Mock<IOptions<FatJobsApiConfiguration>>();
            configMock.Setup(x => x.Value).Returns(config);
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            };
            var deleteTestRequest = new DeleteTestRequest(id);
            var expectedUrl = deleteTestRequest.DeleteUrl;
            var httpMessageHandler = MessageHandler.SetupMessageHandlerMock(response, config.BaseUrl + expectedUrl, config.Key, HttpMethod.Delete);
            var client = new HttpClient(httpMessageHandler.Object);
            var apiClient = new ApiClient(client, configMock.Object);
            
            //Act Assert
            Assert.ThrowsAsync<HttpRequestException>(() => apiClient.Delete(deleteTestRequest));
            
        }
        
        private class DeleteTestRequest : IDeleteApiRequest
        {
            private readonly int _id;

            public DeleteTestRequest (int id)
            {
                _id = id;
            }
            public string DeleteUrl => $"test-url/delete/{_id}";
        }
    }
}