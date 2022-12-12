using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class Counter
    {
        [Function("Counter")]
        [CosmosDBOutput("%DataBaseName%", "%CollectionName%", Connection = "CosmosDBConnectionString")]
        public static object Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        [CosmosDBInput("%DatabaseName%", "%CollectionName%", Connection = "CosmosDBConnectionString", Id ="1",PartitionKey ="1")] CounterJson counter,
            FunctionContext executionContext)
        {
            counter.Count++;
            

            return counter;
        }
    }
}

public class CounterJson
{
    [JsonPropertyName("id")]
    public string Id {get;set;}
    [JsonPropertyName("count")]
    public string Count {get;set;}
}
