using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusReceiver
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("samplequeue", Connection = "ServiceBusConnection")]string myQueueItem, ILogger log)
        {
            var message = JsonSerializer.Deserialize<dynamic>(myQueueItem);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7127/api/Device/createdevice");
            var content = new StringContent(myQueueItem, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
