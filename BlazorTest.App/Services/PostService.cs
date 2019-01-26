using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.App.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string requestUrl = "https://jsonplaceholder.typicode.com/posts";
        //private Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
        //public readonly ApiClient apiClient = new ApiClient(new Uri("https://jsonplaceholder.typicode.com/posts"));

        public async Task<Post[]> GetPostsAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //_httpClient.DefaultRequestHeaders.Add("token", "jwttoken");

            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(JsonConvert.DeserializeObject<Post[]>(data));
        }

        //Comments

    }
}
