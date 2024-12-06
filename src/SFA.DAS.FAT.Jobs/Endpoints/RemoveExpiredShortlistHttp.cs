namespace SFA.DAS.FAT.Jobs.Endpoints
{
    // public class RemoveExpiredShortlistHttp
    // {
    //     [FunctionName("RemoveExpiredShortlistsHttp")]
    //     [return: Queue("delete-shortlist")]
    //     public async Task<string> RunAsync(
    //         [HttpTrigger(AuthorizationLevel.Function, "post")]
    //         HttpRequest req, ILogger log)
    //     {
    //
    //         var body = await req.ReadAsStringAsync();
    //         var request = JsonConvert.DeserializeObject<RemoveShortlistRequest>(body);
    //         
    //         log.LogInformation($"Removing shortlist with ID:{request.Id}.");
    //
    //         return request.Id.ToString();
    //     }
    //
    //     public class RemoveShortlistRequest
    //     {
    //         public Guid Id { get; set; }
    //     }
    //}
}