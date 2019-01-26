using Microsoft.AspNetCore.Blazor;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.App.Services
{
    public class PostListService
    {
        HttpClient _httpClient = new HttpClient();
        string requestUrl = "https://jsonplaceholder.typicode.com/posts";

        
        public Task<string> GetPostAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //_httpClient.DefaultRequestHeaders.Add("token", "jwttoken");

            var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.Result.EnsureSuccessStatusCode();
            var data = response.Result.Content.ReadAsStringAsync();
            return data;
        }
        public async Task<Post[]> GetPostObjList()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //_httpClient.DefaultRequestHeaders.Add("token", "jwttoken");

            var response = await _httpClient.GetJsonAsync<Post[]>(requestUrl);
            return response;
        }
    }
}

