using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace HttpHandlerConfigBug
{
    public class Function1
    {

        private readonly HttpClient httpClient;
        public Function1(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var test = await httpClient.GetAsync("https://bing.com");
            return new OkResult();
        }
    }
}
