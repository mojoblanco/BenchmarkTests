using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;
using RestSharp;

namespace BenchmarkTests
{
    public class RestApi
    {
        [Benchmark]
        public void HttpClientCall()
        {
            using(var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");  
                client.DefaultRequestHeaders.Accept.Clear();  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                //GET Method  
                HttpResponseMessage response = client.GetAsync("posts").Result;  
                if (!response.IsSuccessStatusCode)  
                    Console.WriteLine("HttpClient Failed" +  response.ReasonPhrase);  
                
            }  
        }


        [Benchmark]
        public void RestSharpCall()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (!response.IsSuccessful)
                Console.WriteLine("Restsharp call failed");
        }
    }
}