using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.App.Services
{
    public class WeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
        //public Task<string> GetPostAsync()
        //{
        //    HttpClient _httpClient = new HttpClient();
        //    string requestUrl = "https://jsonplaceholder.typicode.com/posts";

        //    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    //_httpClient.DefaultRequestHeaders.Add("token", "jwttoken");

        //    var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
        //    response.Result.EnsureSuccessStatusCode();
        //    var data = response.Result.Content.ReadAsStringAsync();
        //    return data;
        //}
        //public Task<Post[]> GetPostObjAsync()
        //{
        //    HttpClient _httpClient = new HttpClient();
        //    string requestUrl = "https://jsonplaceholder.typicode.com/posts";

        //    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    //_httpClient.DefaultRequestHeaders.Add("token", "jwttoken");

        //    var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
        //    response.Result.EnsureSuccessStatusCode();
        //    var data = response.Result.Content.ReadAsStringAsync();
        //    return Task.FromResult(JsonConvert.DeserializeObject<Post[]>(data.ToString()));
        //}
    }
}
