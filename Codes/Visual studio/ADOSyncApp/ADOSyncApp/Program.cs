// See https://aka.ms/new-console-template for more information
//using ADOSyncApp.Model;



//Console.WriteLine("Hello, World!");
//string organization="Anurag";
//string project="Test";
//string type="Epic";
//string url=$"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/${type}?api-version=7.0";
//CreateRequest createRequest = new CreateRequest()
//{
//    Value = type,
//    From = organization,
//    Operation = "Add",
//    Path = url
//};

using System;
using ADOSyncApp.Model;
using Newtonsoft.Json;
using System.Text;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string organization = "Anurag";
            string project = "Test";
            string type = "Epic";
            object value = "Add a workItem";

            // Create

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
            var responseData=JsonConvert.DeserializeObject<Request>(response.Content.ReadAsStringAsync().Result); // Deserialize the class



          
        }
    }
}