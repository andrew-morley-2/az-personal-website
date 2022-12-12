using System.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace tests
{
    public class TestCounter
    {
        public async void Http_trigger_should_return_known_string()
        {
            var counter = new Company.Function.Counter();
            counter.Id = "index";
            counter.Count = 2;
            var request = TestFactory.CreateHttpRequest();
            var response = (HttpResponseMessage) Company.Function.Counter.Run(request, counter);
            Assert.Equal(3, counter.Count);
        }

    }
}