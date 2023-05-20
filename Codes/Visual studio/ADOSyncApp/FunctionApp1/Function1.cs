using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp1.Model;
using System.Net.Http;
using System.Text;
using System.ComponentModel.Design;

namespace FunctionApp1
{
    public static class Function1
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Create")]
        public static async Task<IActionResult> Create(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            // Get the values from trigger event for create workItem | Check if deserialization reuired or not

            log.LogInformation("Create HTTP trigger function processed a request.");
            string organization = "Anurag";
            string project = "Test";
            string type = "Epic";
            object value = "Add a workItem";

           
            string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/${type}?api-version=7.0";            
            Request request = new Request()
            {
                Value = value,
                From = organization,
                Operation = "add", // add, copy, move, remove, replace, test
                Path = url
            };
            var serilizedData = JsonConvert.SerializeObject(request); // Serialize the class
            //var content=new StringContent(serilizedData,Encoding.UTF8,"application/json");
            var content = new StringContent(serilizedData, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var responseData = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result); // Deserialize the class
            //var url1=responseData.url;
            //responseData.fields.SystemTeamProject;
            return new OkObjectResult(response);
        }

        [FunctionName("Update")]
        public static async Task<IActionResult> Update(
          [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("Update HTTP trigger function processed a request.");
            string organization = "Anurag";
            string project = "Test";
            int id = 1445;
            object value = "Add a workItem";


            string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?api-version=7.0";
            Request request = new Request()
            {
                Value = value,
                From = organization,
                Operation = "add", // add, copy, move, remove, replace, test
                Path = url
            };
           
            var serilizedData = JsonConvert.SerializeObject(request); // Serialize the class
            //var content=new StringContent(serilizedData,Encoding.UTF8,"application/json");
            var content = new StringContent(serilizedData, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var responseData = JsonConvert.DeserializeObject<Request>(response.Content.ReadAsStringAsync().Result); // Deserialize the class
            return new OkObjectResult(response);
        }

        [FunctionName("AddComment")]
        public static async Task<IActionResult> AddComment(
          [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("AddComment HTTP trigger function processed a request.");
            string organization = "Anurag";
            string project = "Test";
            int workItemId = 2045;
            object value = "Add a workItem";


            string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workItems/{workItemId}/comments?api-version=7.0-preview.3";
            Request request = new Request()
            {
               Comment="This is sample comment"
            };

            var serilizedData = JsonConvert.SerializeObject(request); // Serialize the class
            //var content=new StringContent(serilizedData,Encoding.UTF8,"application/json");
            var content = new StringContent(serilizedData, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var responseData = JsonConvert.DeserializeObject<Request>(response.Content.ReadAsStringAsync().Result); // Deserialize the class
            return new OkObjectResult(response);
        }
        [FunctionName("UpdateComment")]
        public static async Task<IActionResult> UpdateComment(
          [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("UpdateComment HTTP trigger function processed a request.");
            string organization = "Anurag";
            string project = "Test";
            int workItemId = 2045;
            int commentId = 11;
            object value = "Add a workItem";


            string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workItems/{workItemId}/comments/{commentId}?api-version=7.0-preview.3";
            Request request = new Request()
            {
                Comment = "This is sample for comment update"
            };

            var serilizedData = JsonConvert.SerializeObject(request); // Serialize the class
            //var content=new StringContent(serilizedData,Encoding.UTF8,"application/json");
            var content = new StringContent(serilizedData, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var responseData = JsonConvert.DeserializeObject<Request>(response.Content.ReadAsStringAsync().Result); // Deserialize the class
            return new OkObjectResult(response);
        }
        [FunctionName("DeleteComment")]
        public static async Task<IActionResult> DeleteComment(
         [HttpTrigger(AuthorizationLevel.Function, "delete", Route = null)] HttpRequest req,
         ILogger log)
        {
            log.LogInformation("DeleteComment HTTP trigger function processed a request.");
            string organization = "Anurag";
            string project = "Test";
            int workItemId = 2045;
            int commentId = 11;
            object value = "Add a workItem";


            string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workItems/{workItemId}/comments/{commentId}?api-version=7.0-preview.3";
            Request request = new Request()
            {
                Comment = "This is sample for comment delete"
            };

            var serilizedData = JsonConvert.SerializeObject(request); // Serialize the class
            //var content=new StringContent(serilizedData,Encoding.UTF8,"application/json");
            var content = new StringContent(serilizedData, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var responseData = JsonConvert.DeserializeObject<Request>(response.Content.ReadAsStringAsync().Result); // Deserialize the class
            return new OkObjectResult(response);
        }

    }
}
