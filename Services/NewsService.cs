namespace pc3_progra.Services;

using System.Net.Http.Json;
using pc3_progra.Models;

public class NewsService : INewsService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    public NewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Post>>("/posts");
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Post>($"/posts/{id}");
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"/users/{id}");
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>($"/comments?postId={postId}");
    }
}