
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HttpAndStorage
{
    public static class HttpAndStorage
    {
        [FunctionName("HttpAndStorage")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req,
            [Queue("myqueue")] ICollector<MyQueue> myQueue,
            ILogger logger)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            myQueue.Add(new MyQueue { Data = "mydata" });

            return new OkObjectResult("Hello");
        }
    }

    public class MyQueue
    {
        public string Data { get; set; }
    }
}
